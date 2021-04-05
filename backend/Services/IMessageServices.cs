using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Services
{
    public interface IMessageServices
    {
        Task<ServiceResponse<Message>> addMessage(Message nMessage);
         Task<ServiceResponse<Message>> DeleteMessage(int id);
        Task<ServiceResponse<Message>> updateMesage(Message nMessage);
        Task<ServiceResponse<List<Message>>> getMessage();

    }
}