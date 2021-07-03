using System.Threading.Tasks;
using  backend.Model.Sead;
using backend.Model.ViewModels;

namespace backend.Services
{
    public interface IUserFeed
    {
         Task<ServiceResponse<UserInfoDto>> getUserFeed(int id);
    }
}