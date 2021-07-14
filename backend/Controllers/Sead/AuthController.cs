using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using  backend.Model.Sead;
using backend.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            ServiceResponse<string> response= await _authRepo.Register(request);
            if(!response.Success){
                return BadRequest(response);

            };
            return Ok(response);
        }
         [HttpGet("Register")]
        public async Task<IActionResult> Register(){
            ServiceResponse<RegisterViewModel> model = new ServiceResponse<RegisterViewModel>();
            
            try{
             model= await _authRepo.registerView();
            if(!model.Success){
                return BadRequest(model);

            };
            }
            catch(Exception e ){
                model.Success=false;
                model.Message= e.Message;
                return BadRequest(model);
            }
            return Ok(model);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request){
            ServiceResponse<string> response= await _authRepo.Login( request.Username, request.Password);
            if(!response.Success){
                return BadRequest(response);
            };
            return Ok(response);
        }
        [Authorize]
        [HttpGet("checklogin")]
        public  IActionResult checkLogin(){
            return Ok("Success");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> updatePassword(updatePasswordDto pass){
            int id = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _authRepo.changePassword(pass,id));
        }
        
     
    }
  
}