using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model.Sead;
using backend.Services.Sead;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Sead
{
    [ApiController]
    [Route("api/v1/userole")]
    public class UserRolesController : ControllerBase
    {
        private readonly IRolesUserService _service;
        public UserRolesController(IRolesUserService service)
        {
            _service = service;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUseRoles(int id)
        {
            ServiceResponse<RoleUser> response= new ServiceResponse<RoleUser>();
            try{
                response= await _service.getRolesUser(id);
               
                if(!response.Success){
                    return BadRequest(response);
                }
            }
            catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostUseRoles(RoleUser role)
        {
          
             ServiceResponse<string> response= new ServiceResponse<string> ();
               if(!ModelState.IsValid){
                   response.Success=false;
                response.Message=  ModelState.Select(x => x.Value.Errors.First().ErrorMessage).First();
                    return BadRequest(response);
            }
            try{
                response= await _service.postRolesUser(role);
               
                if(!response.Success){
                    return BadRequest(response);
                }
            }
            catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUseRoles( RoleUser role)
        {
            
             ServiceResponse<string> response= new ServiceResponse<string> ();
            try{
                response= await _service.updateRolesUser(role);
               
                if(!response.Success){
                    return BadRequest(response);
                }
            }
            catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelteUseRoles(int id)
        {
           
             ServiceResponse<string> response= new ServiceResponse<string> ();
            try{
                response= await _service.deleteRolesUser(id);
               
                if(!response.Success){
                    return BadRequest(response);
                }
            }
            catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}