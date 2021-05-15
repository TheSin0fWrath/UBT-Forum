using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model.CSE;
using backend.Model.Sead;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.CSE
{
    [ApiController]
    [Route("api/cse/vititret")]

    public class VitiTretController : ControllerBase
    {
        private readonly DataContext _db;

        public VitiTretController(DataContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> addTopic(VitiTret vt)
        {
            int Userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.
       NameIdentifier).Value);

            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {

                vt.UserId = Userid;
                await _db.CSEVT.AddAsync(vt);
                await _db.SaveChangesAsync();
                response.Message = "Topic Posted ";
                response.Data = vt.Id;


            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> getTopics()
        {
            ServiceResponse<List<VitiTret>> response = new ServiceResponse<List<VitiTret>>();
            try
            {
                List<VitiTret> vt = await _db.CSEVT.ToListAsync();
                response.Data = vt;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]

        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteTopic(int id)
        {


            int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiTret> Response = new ServiceResponse<VitiTret>();
            try
            {
                VitiTret vt = await _db.CSEVT.FirstOrDefaultAsync(x => x.Id == id);
                if (vt.UserId != userid)
                {
                    Response.Message = "Is not your topic to delete";
                    Response.Success = false;
                    return Unauthorized(Response);

                }
                _db.CSEVT.Remove(vt);
                await _db.SaveChangesAsync();
                Response.Message = "Topic has been deleted.";

            }
            catch (Exception e)
            {
                Response.Message = e.Message;
                Response.Success = false;
                return BadRequest(Response);
            }
            return Ok(Response);
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> updateTopic(VitiTret updatevt)
        {

            int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiTret> response = new ServiceResponse<VitiTret>();
            try
            {
                VitiTret vt = await _db.CSEVT.FirstOrDefaultAsync(x => x.Id == updatevt.Id);
                if (vt.UserId != userid)
                {
                    response.Message = "Is not your topic to update";
                    response.Success = false;
                    return Unauthorized(response);

                }
                vt.Text = updatevt.Text;
                _db.CSEVT.Update(vt);
                await _db.SaveChangesAsync();
                response.Message = "Topic has been updated";

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return BadRequest(response);

            }


            return Ok(response);
        }

    }
}