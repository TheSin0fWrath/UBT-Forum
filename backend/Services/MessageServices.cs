using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using backend.Model.Dto;
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
            
            response.Message="ChatUpdated";
            response.Data=nMessage;
            Message deletem=await _db.ChatBox.OrderBy(b =>b.Id).FirstAsync();
            var count =await  _db.ChatBox.CountAsync();
            if(count >= 20){
             _db.ChatBox.Remove(deletem);}
           
            
            }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;

            }
              await _db.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<Message>> DeleteMessage(int id)
        {
             ServiceResponse<Message> response = new ServiceResponse<Message>();
            try{
            Message deleteme=await _db.ChatBox.FirstOrDefaultAsync(x =>x.Id==id);
             _db.ChatBox.Remove(deleteme);
             await _db.SaveChangesAsync();
            response.Message="chatdeleted";
             }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
            }
            return response;
        }

               public async Task<ServiceResponse<List<Message>>> getMessage()
        {
            ServiceResponse<List<Message>> response = new ServiceResponse<List<Message>>();
            try{
                
            response.Data= await _db.ChatBox.OrderByDescending(b =>b.Id).Take(20).ToListAsync();
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