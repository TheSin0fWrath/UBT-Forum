using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model.Sead;

namespace backend.Services.Sead
{
    public interface IRolesUserService
    {
        Task<ServiceResponse<RoleUser>> getRolesUser(int id);
        Task<ServiceResponse<string>> postRolesUser(RoleUser role);
        Task<ServiceResponse<string>> deleteRolesUser(int id);
        Task<ServiceResponse<string>> updateRolesUser(RoleUser role);
    }
}