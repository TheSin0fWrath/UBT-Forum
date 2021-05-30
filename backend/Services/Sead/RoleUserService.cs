using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Model.Sead;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Sead
{
    public class RoleUserService : IRolesUserService
    {
         private readonly DataContext _db;
        public RoleUserService(DataContext db)
        {
            _db = db;

        }
        public async Task<ServiceResponse<string>> deleteRolesUser(int id)
        {
           ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var role = await _db.RoleUser.FirstOrDefaultAsync(x=>x.Id==id);
                _db.RoleUser.Remove(role);
                await _db.SaveChangesAsync();
                response.Message="Data Deleted";
                
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<RoleUser>> getRolesUser(int id)
        {
            ServiceResponse<RoleUser> response = new ServiceResponse<RoleUser>();
            try
            {
                response.Data = await _db.RoleUser.FirstOrDefaultAsync(x=>x.UserId==id);
                response.Message="Data Reached";
                
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> postRolesUser(RoleUser role)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                await _db.RoleUser.AddAsync(role);
                await _db.SaveChangesAsync();
                response.Message="Data Added";
                
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> updateRolesUser(RoleUser role)
        {
                ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var oldrole = await _db.RoleUser.FirstOrDefaultAsync(x=>x.Id==role.Id);
                oldrole.RoleId= role.RoleId;
                _db.RoleUser.Update(oldrole);
                await _db.SaveChangesAsync();
                response.Message="Data Updated";
                
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }
    }
}