using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserFeed : IUserFeed
    {
          private readonly DataContext _context;
        public UserFeed(DataContext context)
    {
       _context = context;

    }
    public async Task<ServiceResponse<UserInfo>> getUserFeed(int id)
    {   ServiceResponse<UserInfo> response = new ServiceResponse<UserInfo>();
        try{
     
        UserInfo user =await  _context.UsersInfos.FirstOrDefaultAsync(x=> x.UserId ==id);
        response.Data=user;
        if (user==null){
            response.Data=null;
            response.Success=false;
            response.Message="User Not Found";
            return response;
        }
        }catch(Exception e){
            response.Data=null;
            response.Success=false;
            response.Message=e.Message;
            return response;
        }
        return response;
    }

    public async Task<ServiceResponse<string>> Like(int id)
    {
         ServiceResponse<string> response = new ServiceResponse<string>();
        try{
     
        UserInfo user =await  _context.UsersInfos.FirstOrDefaultAsync(x=> x.UserId ==id);
        user.Likes+=1;
        _context.UsersInfos.Update(user);
        await _context.SaveChangesAsync();
        if (user==null){
            response.Data=null;
            response.Success=false;
            response.Message="User Not Found";
            return response;
        }
        }catch(Exception e){
            response.Data=null;
            response.Success=false;
            response.Message=e.Message;
            return response;
        }
        return response;
    }
    

    public async Task<ServiceResponse<string>> Post(int id)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
        try{
     
        UserInfo user =await  _context.UsersInfos.FirstOrDefaultAsync(x=> x.UserId ==id);
        user.Posts+=1;
        _context.UsersInfos.Update(user);
        await _context.SaveChangesAsync();
        if (user==null){
            response.Data=null;
            response.Success=false;
            response.Message="User Not Found";
            return response;
        }
        }catch(Exception e){
            response.Data=null;
            response.Success=false;
            response.Message=e.Message;
            return response;
        }
        return response;
    }

    public async Task<ServiceResponse<string>> ReportedPost(int id)
    {
        ServiceResponse<string> response = new ServiceResponse<string>();
        try{
     
        UserInfo user =await  _context.UsersInfos.FirstOrDefaultAsync(x=> x.UserId ==id);
        user.ReportedPosts+=1;
        _context.UsersInfos.Update(user);
        await _context.SaveChangesAsync();
        if (user==null){
            response.Data=null;
            response.Success=false;
            response.Message="User Not Found";
            return response;
        }
        }catch(Exception e){
            response.Data=null;
            response.Success=false;
            response.Message=e.Message;
            return response;
        }
        return response;
    }

    public async Task<ServiceResponse<string>> Threads(int id)
    {
       ServiceResponse<string> response = new ServiceResponse<string>();
        try{
     
        UserInfo user =await  _context.UsersInfos.FirstOrDefaultAsync(x=> x.UserId ==id);
        user.Threads+=1;
        _context.UsersInfos.Update(user);
        await _context.SaveChangesAsync();
        if (user==null){
            response.Data=null;
            response.Success=false;
            response.Message="User Not Found";
            return response;
        }
        }catch(Exception e){
            response.Data=null;
            response.Success=false;
            response.Message=e.Message;
            return response;
        }
        return response;
    }

     

        public async Task<ServiceResponse<string>> WarningPoints(int id,int points)
    {
        ServiceResponse<string> response = new ServiceResponse<string>();
        try{
     
        UserInfo user =await  _context.UsersInfos.FirstOrDefaultAsync(x=> x.UserId ==id);
        user.WarningLevel+=points;
        _context.UsersInfos.Update(user);
        await _context.SaveChangesAsync();
        if (user==null){
            response.Data=null;
            response.Success=false;
            response.Message="User Not Found";
            return response;
        }
        }catch(Exception e){
            response.Data=null;
            response.Success=false;
            response.Message=e.Message;
            return response;
        }
        return response;
    }
}
}