using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Model;
using  backend.Model.Sead;
using backend.Model.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try{
               
                if(username.Length >=30){
                    response.Success=false;
                    response.Message="Opss Username to long";
                    return response;
                }
            User user = await _context.Users.Include(x=>x.Role).ThenInclude(x=>x.Role)
            .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower() ));
            // if(!user.IsActive){
            //     response.Success = false;
            //     response.Message = "User Has Been Banned Or Timed Out";
            //     return response;
            // }
            
            if (user == null)
            {
                response.Success = false;
                response.Message = "Username Or Password Is Invalid";
                return response;
            }
             else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
                return response;
            }
            response.Data = CreateToken(user);
            }catch(Exception e){
                response.Data=null;
                response.Success=false;
                response.Message=e.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> Register(UserRegisterDto newuser)
        {
            
            ServiceResponse<string> response = new ServiceResponse<string>();
            try{
                if(newuser.Username.Length >=30){
                response.Message = "Username to long pls chose another one";
                response.Success = false;
                return response;
                }
               
            CreatePasswordHash(newuser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            if (await UserExists(newuser.Username,newuser.Email))
            {
                response.Message = "User Already Exists. Pls Chose Another Username";
                response.Success = false;
                return response;
            }
            var role = await _context.Roles.FirstOrDefaultAsync(x=>x.Default==true);
            User user= new User();
            user.Username=newuser.Username;
           
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.DrejtimiId= newuser.Drejtimi;
           
            user.Email= newuser.Email;
            user.Role.Add(new RoleUser{RoleId=role.Id});
            _context.Users.Add(user); 
            _context.SaveChanges();
            response.Data = CreateToken(user);

            }catch(Exception e){
                response.Success=false;
                response.Message= e.Message;
            }
            response.Message="Your Account Has Been Created You Can Now Log In";
            return response;

        }

        public async Task<bool> UserExists(string username,string email)
        {
            if (await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower()) || await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                };
                return true;
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };
            foreach (var role in user.Role)
             {
            claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
            );
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials =creds
            };
            JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
         public async Task<ServiceResponse<RegisterViewModel>> registerView()
        {
            ServiceResponse<RegisterViewModel> response = new ServiceResponse<RegisterViewModel>();
            try{
                var drejtimet =await _context.Drejtime.ToListAsync();
                response.Data= new RegisterViewModel();
                response.Data.Drejtimet = new List<Drejtimet>(drejtimet);
            }
            catch(Exception e){
                response.Success=false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> changePassword(updatePasswordDto password,int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
           try{
            User user = await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
             if (!VerifyPasswordHash(password.CurrentPassword, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
                return response;
            }
             CreatePasswordHash(password.Password, out byte[] passwordHash, out byte[] passwordSalt);
             user.PasswordHash =passwordHash;
             user.PasswordSalt = passwordSalt;
             _context.Update(user);
             await _context.SaveChangesAsync();
             response.Message="Password Updated";
             }catch(Exception e){
                 response.Message=e.Message;
                 response.Success=false;
             }
            return response;
        }
    }
}
