using System.Threading.Tasks;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserFeed : ControllerBase
    {
        private readonly IUserFeed _userfeed;
        public UserFeed(IUserFeed userfeed)
        {
            _userfeed = userfeed;

        }
        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> getUserFeed( int id)
        {
            return Ok(await _userfeed.getUserFeed(id));
        }
        public string Name { get; set; }
        
        
         

    }
}