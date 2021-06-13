using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Home
{
    [ApiController]
    [Route("api/replay")]
    public class ReplayController : ControllerBase
    {
        private readonly DataContext _db;
        public ReplayController(DataContext db)
        {
            _db = db;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getReplays(int id)
        {
            List<Replays> users_replay;
            try
            {
                users_replay = await _db.Replays.Where(x => x.EmailId == id).ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(users_replay);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> postReplays(Replays rel)
        {
            bool is_posted;
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            rel.UserId = id;
            try
            {
                await _db.Replays.AddAsync(rel);
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
        [HttpPut]
        public async Task<IActionResult> updateRels(Replays newkoment)
        {
            try
            {
                int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var oldkoment = await _db.Replays.FirstOrDefaultAsync(x => x.ReplayId == newkoment.ReplayId);
                if (oldkoment.UserId != id)
                {
                    return BadRequest("You cant change your own replay");
                }
                oldkoment = newkoment;
                _db.Update(oldkoment);
                await _db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                return BadRequest(error);

            }
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteRel(int id)
        {
            try
            {
                int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var rel = await _db.Replays.FirstOrDefaultAsync(x => x.ReplayId == id);
                if (rel.UserId == id)
                {

                    _db.Replays.Remove(rel);
                    await _db.SaveChangesAsync();

                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return Ok();
        }

    }
}