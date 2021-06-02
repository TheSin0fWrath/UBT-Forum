using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Model.Sead;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserFeed : IUserFeed
    {
        private readonly DataContext _context;
        private readonly IMapper _mapp;
        public UserFeed(DataContext context, IMapper mapp)
        {
            _mapp = mapp;
            _context = context;

        }
        public async Task<ServiceResponse<UserInfoDto>> getUserFeed(int id)
        {
            ServiceResponse<UserInfoDto> response = new ServiceResponse<UserInfoDto>();
            try
            {

                User user = await _context.Users.Include(x=>x.Role).ThenInclude(x=>x.Role).FirstOrDefaultAsync(x => x.Id == id);

                

                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }
                response.Data = _mapp.Map<UserInfoDto>(user);
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> Like(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {

                User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }


        public async Task<ServiceResponse<string>> Post(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {

                User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> ReportedPost(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {

                User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> Threads(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {

                User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }



        public async Task<ServiceResponse<string>> WarningPoints(int id, int points)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {


                User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            return response;
        }
    }
}