using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Model.Sead;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Sead
{
    public class RolesService : IRolesService
    {
        private readonly DataContext _db;
        public RolesService(DataContext db)
        {
            _db = db;

        }
        public async Task<ServiceResponse<string>> deleteRoles(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var role = await _db.Roles.FirstOrDefaultAsync(x=>x.Id==id);
                _db.Roles.Remove(role);
                await  _db.SaveChangesAsync();
                response.Message="Role Deleted";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Role>>> getRoles()
        {
          ServiceResponse<List<Role>> response = new ServiceResponse<List<Role>>();
            try
            {
                var role = await _db.Roles.ToListAsync();
                response.Message="Data Reached";
                response.Data=role;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> postRoles(Role role)
        {
            var date = DateTime.Now;
            role.Date= date.ToString();
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                 await _db.Roles.AddAsync(role);
            
                await  _db.SaveChangesAsync();
                response.Message="Role Added";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> updateRoles(Role role)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                 var oldrole = await _db.Roles.FirstOrDefaultAsync(x=>x.Id==role.Id);
                 oldrole.Color= role.Color;
                 oldrole.Name= role.Name;
                _db.Roles.Update(oldrole);
                await  _db.SaveChangesAsync();
                response.Message="Role Updated";
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