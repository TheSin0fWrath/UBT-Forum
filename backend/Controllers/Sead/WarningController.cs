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
        [HttpGet]
        public async Task<IActionResult> getWarnings()
        {
            List<Warnings> Warnings = new List<Warnings>();
            try
            {
                Warnings = await _db.Warnings.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(Warnings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getWarning(int id)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> updateWarning(int id, Warnings newkoment)
        {
            try
            {
                // int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var warning = await _db.Warnings.FirstOrDefaultAsync(x => x.Id == id);
                warning.Text = newkoment.Text;
                warning.Points = newkoment.Points;
                // warning.fromUserId = newkoment.ToUserId;
                // warning.ByAdminId = newkoment.ByAdminId;
                /// add more as needed
                _db.Update(warning);
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
        public async Task<IActionResult> deletewrn(int id)
        {
            try
            {
                int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var wrn = await _db.Warnings.FirstOrDefaultAsync(x => x.Id == id);
                if (wrn.fromUserId == userid)
                {

                    _db.Warnings.Remove(wrn);
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