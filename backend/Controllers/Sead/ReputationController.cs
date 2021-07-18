using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using backend.Model.Sead.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Home
{
    [ApiController]
    [Route("api/reputation")] //api per backend
    public class ReputationController : ControllerBase
    {
        private readonly DataContext _db;
        public ReputationController(DataContext db)
        {
            _db = db; // ta lidh me databaz

        }
        [HttpGet]
        public async Task<IActionResult> getReputations()
        {
            List<Reputations> reputations = new List<Reputations>(); //
            try
            {
                reputations = await _db.Reputations.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(reputations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getReputation(int id)
        {
            List<ReputationDto> users_reputation = new List<ReputationDto>();
            try
            //prit ni sekond
            {
                users_reputation = await _db.Reputations.
               Include(x => x.fromUser).Where(x => x.ToUserId == id)
               .Select(x => new ReputationDto
               {
                   touser = x.ToUserId,
                   id = x.Id,
                   fromuser = x.fromUserId,
                   username = x.fromUser.Username,
                   points = x.Reputation,
                   message = x.Message

               }).ToListAsync();


            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(users_reputation);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> postReputation(Reputations rep)
        {
            bool is_posted = false;
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            try
            {

                rep.fromUserId = id;
                await _db.Reputations.AddAsync(rep);
                await _db.SaveChangesAsync();
                is_posted = true;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(is_posted);
        }
        [Authorize]
        [HttpPut("{id}")]//1
        public async Task<IActionResult> updateReputation(int id, Reputations newkoment)
        {
            try
            {
                // int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var Reputations = await _db.Reputations.FirstOrDefaultAsync(x => x.Id == id);// 1 = 
                Reputations.Message = newkoment.Message;
                Reputations.fromUserId = newkoment.fromUserId;
                Reputations.ToUserId = newkoment.ToUserId;
                Reputations.Reputation = newkoment.Reputation;
                /// add more as needed
                _db.Update(Reputations);
                await _db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                return BadRequest(error);

            }
            return Ok("Changed");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleterep(int id)
        {
            try
            {
                int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var rep = await _db.Reputations.FirstOrDefaultAsync(x => x.Id == id);
                {

                    _db.Reputations.Remove(rep);
                    await _db.SaveChangesAsync();

                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return Ok("Deleted");
        }

    }
}