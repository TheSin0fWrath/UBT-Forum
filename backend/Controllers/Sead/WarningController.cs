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
    [Route("api/warning")]
    public class WarningController : ControllerBase
    {
        private readonly DataContext _db;
        public WarningController(DataContext db)
        {
            _db = db;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getWarnings(int id)
        {
            List<Warnings> users_warning;
            try
            {
                users_warning = await _db.Warnings.Where(x => x.ToUserId == id).ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(users_warning);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> postWarning(Warnings wrn)
        {
            bool is_posted;
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            wrn.fromUserId = id;
            try
            {
                await _db.Warnings.AddAsync(wrn);
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
        public async Task<IActionResult> updateWrn(Warnings newcoment)
        {
            try
            {
                int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var oldcoment = await _db.Warnings.FirstOrDefaultAsync(x => x.Id == newcoment.Id);
                if (oldcoment.fromUserId != id)
                {
                    return BadRequest("You cant change your own Warning");
                }
                oldcoment = newcoment;
                _db.Update(oldcoment);
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
        public async Task<IActionResult> deletewrn(int id)
        {
            try
            {
                int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var wrn = await _db.Warnings.FirstOrDefaultAsync(x => x.Id == id);
                if (wrn.fromUserId == id)
                {

                    _db.Warnings.Remove(wrn);
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