using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Model;
using backend.Model.Dto;
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
                if(username==null || password==null){
                    response.Success=false;
                    response.Message="You must use a password and username";
                    return response;
                }
                if(username.Length >=30){
                    response.Success=false;
                    response.Message="Opss Username to long";
                    return response;
                }
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower() ));
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

        public async Task<ServiceResponse<UserInfo>> Register(UserRegisterDto newuser)
        {
            UserInfo userInfo= new UserInfo();
            ServiceResponse<UserInfo> response = new ServiceResponse<UserInfo>();
            try{
                if(newuser.Username.Length >=30){
                response.Message = "Username to long pls chose another one";
                response.Success = false;
                return response;
                }
                 if(newuser.Drejtimi ==null || newuser.Username==null || newuser.Gjenerata==null||newuser.Password==null||newuser.Email==null){
                response.Message = "Please fill out all thr forms before registring ";
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
            UserInfo newUserInfo= new UserInfo();
            User user= new User();
            newUserInfo.Drejtimi= newuser.Drejtimi;
            newUserInfo.Username=newuser.Username;
            newUserInfo.Username=newuser.Username;
            newUserInfo.Gjenerata=newuser.Gjenerata;
            newUserInfo.DateOfJoining=newuser.DateOfJoining;
            newUserInfo.Conntact=newuser.Email;
            
            user.Email = newuser.Email;
            user.DateOfJoining= newuser.DateOfJoining;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Username= newuser.Username;
            user.UserInfo =newUserInfo;
            _context.Users.Add(user); 
            _context.SaveChanges();
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
                new Claim(ClaimTypes.Name, user.Username)
            };

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
       
    }
}
