using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using  backend.Model.Sead;
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
        
          
            await _db.ChatBox.AddAsync(nMessage);
            
            response.Message="ChatUpdated";
            
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

        public async Task<ServiceResponse<Message>> DeleteMessage(int id,int userid)
        {
             ServiceResponse<Message> response = new ServiceResponse<Message>();
            try{
            Message deleteme=await _db.ChatBox.FirstOrDefaultAsync(x =>x.Id==id);
            if (deleteme.UserId != userid){
                response.Message="Not Your Message To Delete";
                response.Success=false;
                return response;
            }
             _db.ChatBox.Remove(deleteme);
             await _db.SaveChangesAsync();
            response.Message="chatdeleted";
             }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return response;
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

        public async Task<ServiceResponse<Message>> updateMesage(Message nMessage)
        {
            ServiceResponse<Message> response = new ServiceResponse<Message>();
            try{
            Message oldmessage=await _db.ChatBox.FirstOrDefaultAsync(x =>x.Id==nMessage.Id);
            if (oldmessage.UserId != nMessage.UserId){
                response.Message="Not Your Message To Update";
                response.Success=false;
                return response;
            }
            oldmessage.Text= nMessage.Text;
            
             _db.ChatBox.Update(oldmessage);
             await _db.SaveChangesAsync();
            response.Message="Chat Update";
             }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return response;
            }
            return response;
        }
        
    }
}