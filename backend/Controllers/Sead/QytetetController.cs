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
    [Route("api/qytetet")]
    public class QytetetController : ControllerBase
    {
        private readonly DataContext _db;
        public QytetetController(DataContext db)
        {
            _db = db;

        }
        [HttpGet]
        public async Task<IActionResult> getQytetet()
        {
            List<Qytetet> users_Qytetet = new List<Qytetet>();
            try
            {
                users_Qytetet = await _db.Qytetet.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(users_Qytetet);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> postQytetet(Qytetet qyt)
        {
            bool is_posted;
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            try
            {
                await _db.Qytetet.AddAsync(qyt);
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
        public async Task<IActionResult> updateQytetet(Qytetet newkoment)
        {
            try
            {
                int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var oldkoment = await _db.Qytetet.FirstOrDefaultAsync(x => x.QytetiId == newkoment.QytetiId);

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
        public async Task<IActionResult> deleteQytetet(int id)
        {
            try
            {
                int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var qyt = await _db.Replays.FirstOrDefaultAsync(x => x.EmailId == id);


                _db.Replays.Remove(qyt);
                await _db.SaveChangesAsync();

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return Ok();
        }

    }
}
