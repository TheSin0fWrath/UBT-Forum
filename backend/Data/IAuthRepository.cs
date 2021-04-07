using System.Threading.Tasks;
using backend.Model;

namespace backend.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User newUser,string password);
        Task<ServiceResponse<string>> Login(string username,string password);
        Task<bool> UserExists(string username);

    }
}