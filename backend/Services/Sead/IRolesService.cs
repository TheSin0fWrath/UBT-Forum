using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model.Sead;

namespace backend.Services.Sead
{
    public interface IRolesService
    {
        Task<ServiceResponse<List<Role>>> getRoles();
        Task<ServiceResponse<string>> postRoles(Role role);
        Task<ServiceResponse<string>> deleteRoles(int id);
        Task<ServiceResponse<string>> updateRoles(Role role);

        
    }
}