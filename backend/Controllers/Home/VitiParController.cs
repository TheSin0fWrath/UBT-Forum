using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model.Home;
using backend.Model.Sead;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Home
{
    [ApiController]
    [Route("api/cse/vitipar")]
    public class VitiParController : ControllerBase
    {
        private readonly DataContext _db;
        public VitiParController(DataContext db)
        {
           _db = db;

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addTopic(VitiPar vp)
        {
            int userid = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<int> response = new ServiceResponse<int>();
            try{
            vp.UserId=userid;
            await _db.CSEVP.AddAsync(vp);
            await _db.SaveChangesAsync();
            response.Message="Topic Posted";
            response.Data=vp.Id;
            
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
            ServiceResponse<List<VitiPar>> response =new ServiceResponse<List<VitiPar>>();
            try{
            List<VitiPar> vp = await _db.CSEVP.ToListAsync();
             response.Data=vp;
             }catch(Exception e){
                 response.Success=false;
                 response.Message=e.Message;
                return BadRequest(response);
             }
            return Ok(response);
        }
        [HttpGet("{id}")]
      
        public async Task<IActionResult> getonetopic(int id)
        {
            ServiceResponse<List<List<object>>> response =new  ServiceResponse<List<List<object>>>();
            List<List<object>> responseData =new List<List<object>>();
            try{
            List<object> templist= new List<object>();
             VitiPar vp = await _db.CSEVP.FirstOrDefaultAsync(x=>x.Id==id);
             UserInfo userT= await _db.UsersInfos.FirstOrDefaultAsync(x=>x.UserId==vp.UserId);
             responseData.Add(new List<object>{vp,userT});
             List<VParReplay> replays = await _db.CSEVPR.Where(x=>x.ThreadId==vp.Id).ToListAsync();
             templist.AddRange(replays);
             foreach(VParReplay element in templist){
                 UserInfo user= await _db.UsersInfos.FirstOrDefaultAsync(x=>x.UserId==element.UserId);
                 responseData.Add(new List<object>{element,user});
            
             }
             response.Data=responseData;
             }catch(Exception e){
                 response.Success=false;
                 response.Message=e.Message;
                return BadRequest(response);
             }
            return Ok(response);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteTopic(int id){
            int userid = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiPar> response =new ServiceResponse<VitiPar>();
            try{
            VitiPar vp=await _db.CSEVP.FirstOrDefaultAsync(x =>x.Id ==id);
            if(vp.UserId != userid){
                response.Message="Is not your topic to delete";
                response.Success=false;
                return Unauthorized(response);
            }
             _db.CSEVP.Remove(vp);
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
        public async Task<IActionResult> updateTopic(VitiPar updatedvp){
            int userid = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiPar> response =new ServiceResponse<VitiPar>();
            try{
            VitiPar vp=await _db.CSEVP.FirstOrDefaultAsync(x =>x.Id ==updatedvp.Id);
            if(vp.UserId != userid){
                response.Message="Is not your topic to Update";
                response.Success=false;
                return Unauthorized(response);
            }
            vp.Text= updatedvp.Text;
             _db.CSEVP.Update(vp);
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