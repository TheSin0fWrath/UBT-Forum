using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Home
{
    [ApiController]
    [Route("api/reputation")]
    public class ReputationController : ControllerBase
    {
        private readonly DataContext _db;
        public ReputationController(DataContext db)
        {
           _db = db;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getReputations(int id){
            List<Reputations> users_reputation;
            try{
          users_reputation=  await _db.Reputations.Where(x=>x.toUserId==id).ToListAsync();
          }catch(Exception e){
              return BadRequest(e);
          }
            return Ok(users_reputation);
        }
          [Authorize]
        [HttpPost]
        public async Task<IActionResult> postReputation(Reputations rep){
            bool is_posted;
            int id = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
            rep.fromUserId= id;
          try{
              await _db.Reputations.AddAsync(rep);
              await _db.SaveChangesAsync();
              is_posted=true;
              }catch(Exception e){
                 return BadRequest(e);
              }
             
          return Ok(is_posted);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> updateRep(Reputations newkoment){
            try {
            int id = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
            var oldkoment=await _db.Reputations.FirstOrDefaultAsync(x=>x.Id == newkoment.Id);
            if (oldkoment.fromUserId!=id){
            return BadRequest("You cant change your own reputation");
            }
            oldkoment= newkoment;
            _db.Update(oldkoment);
           await  _db.SaveChangesAsync();
            } catch(Exception error){
                return BadRequest(error);

            }
            return Ok();
        }
          [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleterep(int id){
            try{
            int userid = int.Parse(User.Claims.FirstOrDefault( x=>x.Type == ClaimTypes.NameIdentifier).Value);
            var  rep = await _db.Reputations.FirstOrDefaultAsync(x=>x.Id==id);
            if(rep.fromUserId==id){

                _db.Reputations.Remove(rep);
                await _db.SaveChangesAsync();

            }
            } 
            catch(Exception error){
                return BadRequest(error);
            }

            return Ok();
        }

    }
}