using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model.Sead;
using backend.Model.Juridik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Juridik
{
    [ApiController]
    [Route("api/Juridik/VitiTret")]
    public class VitiTretController : ControllerBase
    {
        private readonly DataContext _db;
        public VitiTretController(DataContext db)
        {
            _db = db;

        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addTopic(VitiTret vt)
        {
            int userid = int.Parse(User.Claims.FirstOrDefault(x =>x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<int> response = new ServiceResponse<int>();
            try{
                vt.UserId=userid;
                await _db.JuridikVT.AddAsync(vt);
                await _db.SaveChangesAsync();
                response.Message="Topic Posted";
                response.Data=vt.Id;
            }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> getTopics()
        {
            ServiceResponse<List<VitiTret>> response =new ServiceResponse<List<VitiTret>>();
            try{
                List<VitiTret>vt =await _db.JuridikVT.ToListAsync();
                response.Data=vt;
            }catch(Exception e){
                response.Success=false;
                response.Message=e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteTopic(int id){
            int userid =int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiTret> response =new ServiceResponse<VitiTret>();
            try{
                VitiTret vt=await _db.JuridikVT.FirstOrDefaultAsync(x =>x.Id ==id);
                if(vt.UserId != userid){
                    response.Message="Is not your topic to delete";
                    response.Success=false;
                    return Unauthorized(response);
                }
                _db.JuridikVT.Remove(vt);
                await _db.SaveChangesAsync();
                response.Message="Topic has been deleted";
            }catch(Exception e){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> updateTopic(VitiTret updatedvt){
        int userid = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);
        ServiceResponse<VitiTret> response =new ServiceResponse<VitiTret>();
        try{
            VitiTret vt=await _db.JuridikVT.FirstOrDefaultAsync(x =>x.Id ==updatedvt.Id);
            if(vt.UserId != userid){
                response.Message="is not your topic to update";
                response.Success=false;
                return Unauthorized(response);
            }
            vt.Text= updatedvt.Text;
            _db.JuridikVT.Update(vt);
            await _db.SaveChangesAsync();
            response.Message="Topic has been updated";
        }catch(Exception e){
            response.Message=e.Message;
            response.Success=false;
            return BadRequest(response);
        }
        return Ok(response);
        }
       

    
    }
}