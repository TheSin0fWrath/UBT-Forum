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
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly DataContext _db;
        public EmailController(DataContext db)
        {
            _db = db;

        }
        [HttpGet]
        public async Task<IActionResult> getEmails()
        {
            List<Emails> emails = new List<Emails>();
            try
            {
                emails = await _db.Emails.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(emails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getEmail(int id)
        {
            List<Emails> users_email;
            try
            {
                users_email = await _db.Emails.Where(x => x.ToUserId == id).ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(users_email);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> postEmail(Emails eml)
        {
            bool is_posted;
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            eml.ToUserId = id;
            try
            {
                await _db.Emails.AddAsync(eml);
                // await _db.SaveChangesAsync();
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
        public async Task<IActionResult> updateEmail(int id, Emails newkoment)
        {
            try
            {
                var email = await _db.Emails.FirstOrDefaultAsync(x => x.EmailId == id);
                email.Title = newkoment.Title;
                email.Message = newkoment.Message;
                _db.Update(email);
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
        public async Task<IActionResult> deleteeml(int id)
        {
            try
            {
                int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var eml = await _db.Emails.FirstOrDefaultAsync(x => x.EmailId == id);
                {
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