using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Model.Sead;
using backend.Services.Sead;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Sead
{
    [ApiController]
    [Route("api/v1/role")]

    public class RolesController : ControllerBase
    {
        private readonly IRolesService _service;
        public RolesController(IRolesService service)
        {
            _service = service;

        }
        [HttpPost]
        public async Task<IActionResult> AddRole(Role role)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try{
                 response = await _service.postRoles(role);
                
                if(!response.Success){
                    
                    return BadRequest(response);
                }
            }
            catch(Exception e ){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet()]
        public async Task<IActionResult> GetRoles()
        {
        ServiceResponse<List<Role>> response = new ServiceResponse<List<Role>>();
            try{
                 response = await _service.getRoles();
                
                if(!response.Success){
                    
                    return BadRequest(response);
                }
            }
            catch(Exception e ){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles( int id)
        {
        ServiceResponse<string> response = new ServiceResponse<string>();

        try{
                 response = await _service.deleteRoles(id);
                
                if(!response.Success){
                    
                    return BadRequest(response);
                }
            }
            catch(Exception e ){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole( Role role)
        {
             ServiceResponse<string> response = new ServiceResponse<string>();
            try{
                 response = await _service.updateRoles(role);
                
                if(!response.Success){
                    
                    return BadRequest(response);
                }
            }
            catch(Exception e ){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}