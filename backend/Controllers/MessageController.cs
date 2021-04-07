using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Model;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
   
    [ApiController]
    [Route("api/v1/chatBox")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageServices _message;
        public MessageController(IMessageServices message)
        {
           _message = message;

        }
         [Authorize]
        [HttpPost]

        public async Task<IActionResult> addMessage(Message message)
        {
            string username = (User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.Name).Value);
            int id = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
      
            return Ok(await _message.addMessage(
                new Message {Text=message.Text,Username=username,Time=message.Time,UserId=id}
            ));
        }
        [HttpGet]

        public  async Task<IActionResult> getMessages( )
        {
            return Ok(await _message.getMessage());
        }
         [Authorize]
        [HttpDelete("{id}")]
         public  async Task<IActionResult> deleteMessage(int id)
        {
          
            return Ok(await _message.DeleteMessage(id));
        }
    }
}