using System.Threading.Tasks;
using  backend.Model.Sead;

namespace backend.Services
{
    public interface IUserFeed
    {
         Task<ServiceResponse<UserInfoDto>> getUserFeed(int id);
   
    

    }
}