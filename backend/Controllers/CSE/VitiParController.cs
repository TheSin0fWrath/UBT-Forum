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
    [Route("api/cse/vitipar")]
    public class VitiParController : ControllerBase
    {
        private readonly DataContext _db;
        public VitiParController(DataContext db)
        {
            _db = db;

        }

        [HttpPost]
        public async Task<IActionResult> addTopic(VitiPar vp)
        {
            int Userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.
         NameIdentifier).Value);

            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {

                vp.UserId = Userid;
                await _db.CSEVP.AddAsync(vp);
                await _db.SaveChangesAsync();
                response.Message = "Topic Posted ";
                response.Data = vp.Id;

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
            ServiceResponse<List<VitiPar>> response = new ServiceResponse<List<VitiPar>>();
            try
            {
                List<VitiPar> vp = await _db.CSEVP.ToListAsync();
                response.Data = vp;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteTopic(int id)
        {


            int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiPar> Response = new ServiceResponse<VitiPar>();
            try
            {
                VitiPar vp = await _db.CSEVP.FirstOrDefaultAsync(x => x.Id == id);
                if (vp.UserId != userid)
                {
                    Response.Message = "Is not your topic to delete";
                    Response.Success = false;
                    return Unauthorized(Response);

                }
                _db.CSEVP.Remove(vp);
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


        [HttpGet("{id}")]


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> updateTopic(VitiPar updatevp)
        {

            int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<VitiPar> response = new ServiceResponse<VitiPar>();
            try
            {
                VitiPar vp = await _db.CSEVP.FirstOrDefaultAsync(x => x.Id == updatevp.Id);
                if (vp.UserId != userid)
                {
                    response.Message = "Is not your topic to update";
                    response.Success = false;
                    return Unauthorized(response);

                }
                vp.Text = updatevp.Text;
                _db.CSEVP.Update(vp);
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
//VitiPar Repalyes 
[Authorize]
[HttpPost("replay")]
public async Task<IActionResult> addReplay(VparReplay vr)
{
    int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
    ServiceResponse<string> response = new ServiceResponse<string>();
    try
    {
        vr.UserId = id;
        await _db.CSEVPR.AddAsync(vr);
        await _db.SaveChangesAsync();
        response.Message = "Replay Added";
    }
    catch (Exception e)
    {
        response.Success = false;
        response.Message = e.Message;
    }
    return Ok(response);
}
[Authorize]
[HttpPut("replay")]
public async Task<IActionResult> updateReplay(VparReplay updatedvr)
{
    int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
    ServiceResponse<string> response = new ServiceResponse<string>();
    try
    {
        VParReplay vr = await _db.CSEVPR.FirstOrDefaultAsync(x => x.Id == updatedvr.Id);
        if (vr.UserId != id)
        {
            response.Message = "Is not your replay to Update";
            response.Success = false;
            return Unauthorized(response);
        }
        vr.Text = updatedvr.Text;
        _db.CSEVPR.Update(vr);
        await _db.SaveChangesAsync();
        response.Message = "Replay has been updated";
    }
    catch (Exception e)
    {
        response.Success = false;
        response.Message = e.Message;
    }
    return Ok(response);
}
[Authorize]
[HttpDelete("replay/{id}")]
public async Task<IActionResult> deleteReplay(int id)
{
    int userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
    ServiceResponse<VParReplay> response = new ServiceResponse<VParReplay>();
    try
    {
        VParReplay vr = await _db.VPR.FirstOrDefaultAsync(x => x.Id == id);
        if (vr.UserId != userid)
        {
            response.Message = "Is not your replay to delete";
            response.Success = false;
            return Unauthorized(response);
        }
        _db.JuridikVPR.Remove(vr);
        await _db.SaveChangesAsync();
        response.Message = "Replay has been deleted";
    }
    catch (Exception e)
    {
        response.Message = e.Message;
        response.Success = false;
        return BadRequest(response);
    }
    return Ok(response);
}
[Authorize]
[HttpGet("topic/{id}")]
public async Task<IActionResult> getoneTopic(int id)
{
    ServiceResponse<Object> response = new ServiceResponse<Object>();
    try
    {
        VitiPar data = await _db.JuridikVPR.Include(x => x.User).Include(x => x.VReplay).Where(x => x.Id == id).FirstOrDefaultAsync();
        response.Data = data;

    }
    catch (Exception e)
    {
        response.Message = e.Message;
        response.Success = false;
    }
    return Ok(response);
}