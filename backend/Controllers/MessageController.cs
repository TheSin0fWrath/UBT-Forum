using System.Threading.Tasks;
using backend.Model;
using backend.Services;
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
        [HttpPost]

        public async Task<IActionResult> addMessage(Message nMessage)
        {
            return Ok(await _message.addMessage(nMessage));
        }
        [HttpGet]

        public  async Task<IActionResult> getMessages( )
        {
            return Ok(await _message.getMessage());
        }
    }
}