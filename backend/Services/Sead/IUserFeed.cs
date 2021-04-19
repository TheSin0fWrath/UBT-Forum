using System.Threading.Tasks;
using  backend.Model.Sead;

namespace backend.Services
{
    public interface IUserFeed
    {
         Task<ServiceResponse<UserInfo>> getUserFeed(int id);
        Task<ServiceResponse<string>> Like(int id);
        Task<ServiceResponse<string>> Post(int id);
        Task<ServiceResponse<string>> Threads(int id);
        Task<ServiceResponse<string>> WarningPoints(int id,int points);
        Task<ServiceResponse<string>> ReportedPost(int id);
    

    }
}