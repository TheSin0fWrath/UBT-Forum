using System.Threading.Tasks;
using backend.Data;
using  backend.Model.Sead;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request){
            ServiceResponse<UserInfo> response= await _authRepo.Register(request);
            if(!response.Success){
                return BadRequest(response);

            };
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request){
            ServiceResponse<string> response= await _authRepo.Login( request.Username, request.Password);
            if(!response.Success){
                return BadRequest(response);
            };
            return Ok(response);
        }
     
    }
  
}