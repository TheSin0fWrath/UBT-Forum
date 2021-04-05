using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class MessageServices : IMessageServices
    {
        private readonly DataContext _db;
        public MessageServices(DataContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<Message>> addMessage(Message nMessage)
        {
            ServiceResponse<Message> response = new ServiceResponse<Message>();
        try{
           response.Data=nMessage;
            await _db.ChatBox.AddAsync(nMessage);
            await _db.SaveChangesAsync();
            response.Message="ChatUpdated";
            response.Data=nMessage;
            }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;

            }
            return response;
        }

        public Task<ServiceResponse<Message>> DeleteMessage(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<List<Message>>> getMessage()
        {
            ServiceResponse<List<Message>> response = new ServiceResponse<List<Message>>();
            try{
            response.Data= await _db.ChatBox.Take(20).ToListAsync();
            response.Message="ChatUpdated";

                  }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                
            }
            return response;
        }

        public Task<ServiceResponse<Message>> updateMesage(Message nMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}