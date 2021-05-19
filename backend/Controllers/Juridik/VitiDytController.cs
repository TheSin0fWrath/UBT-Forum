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
     [Route("api/Juridik/VitiDyt")]
    public class VitiDytController : ControllerBase
    {
       private readonly DataContext _db;
       public VitiDytController(DataContext db)
        {
            _db = db;
        }
       
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addTopic(VitiDyt vd)
        {
            int userid = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<int> response = new ServiceResponse<int>();
            try{
                vd.UserId=userid;
                await _db.JuridikVD.AddAsync(vd);
                await _db.SaveChangesAsync();
                response.Message="Topic posted";
                response.Data=vd.Id;
            }catch(Exception e ){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> getTopics()
        {
            ServiceResponse<List<VitiDyt>> response =new ServiceResponse<List<VitiDyt>>();
            try{
                List<VitiDyt>vd =await _db.JuridikVD.ToListAsync();
                response.Data=vd;
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
            int userid = int.Parse(User.Claims.FirstOrDefault(x =>x.Type ==ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiDyt> response =new ServiceResponse<VitiDyt>();
            try{
                VitiDyt vd=await _db.JuridikVD.FirstOrDefaultAsync(x =>x.Id ==id);
                if(vd.UserId != userid){
                    response.Message="Is not your topic to delete";
                    response.Success=false;
                    return Unauthorized(response);
                }
                _db.JuridikVD.Remove(vd);
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
        public async Task<IActionResult> updateTopic(VitiDyt updatedvd){
            int userid =int.Parse(User.Claims.FirstOrDefault(x=>x.Type ==ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiDyt> response =new ServiceResponse<VitiDyt>();
            try{
                VitiDyt vd=await _db.JuridikVD.FirstOrDefaultAsync(x =>x.Id ==updatedvd.Id);
                if(vd.UserId != userid){
                    response.Message="Is not your topic to update";
                    response.Success=false;
                    return Unauthorized(response);
                }
                vd.Text= updatedvd.Text;
                _db.JuridikVD.Update(vd);
                await _db.SaveChangesAsync();
                response.Message="Topic has been updated";
            }catch(Exception e ){
                response.Message=e.Message;
                response.Success=false;
                return BadRequest(response);
            }
            return Ok(response);
        }

        
    }
}