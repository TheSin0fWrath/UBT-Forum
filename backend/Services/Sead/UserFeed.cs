using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Model.Sead;
using backend.Model.ViewModels;
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

                UserInfoDto user = await _context.Users
                .Include(x=>x.Role)
                .ThenInclude(x=>x.Role)
                .Select(x=> new UserInfoDto {
                    Likes = x.LikeThread.Count,
                    DateOfJoining= x.DateOfJoining,
                    ReportedPosts =x.ReportedPosts.Count +x.ReportedThreadS.Count,
                    Email=x.Email,
                    Username=x.Username,
                    IsActive=x.IsActive,
                    Threads=x.Threads.Count,
                    Id=x.Id,
                    Posts=x.Posts.Count,
                    Gjenerata =x.Gjenerata,
                    Drejtimi = x.Drejtimi.Drejtimi,
                    Role = x.Role.OrderByDescending(X=>X.Id).ToList(),
                    WarningLevel= x.ToUserWarning.Sum(x=>x.Points),
                    ProfilePic = x.ProfilePic                   
                    })
                .FirstOrDefaultAsync(x => x.Id == id);
                user.allRoles = await _context.Roles.Where(x=>x.roleUser.All(y=>y.UserId!=id)).ToListAsync();
                response.Data=user;
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