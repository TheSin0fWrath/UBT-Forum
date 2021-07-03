using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using backend.Model.Sead;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers.Bleona
{
    [ApiController]
    [Route("api/ReportedThread")]
    public class ReportedThreadController : ControllerBase
    {
        private readonly DataContext _db;
        public ReportedThreadController(DataContext db)
        {
            _db =db;
        }
        [HttpGet]
        public async Task<IActionResult> GetReportedThread()
        {
            ServiceResponse<List<ReportedThread>> ReportedThread =new ServiceResponse<List<ReportedThread>>();
            try{
                ReportedThread.Data=await _db.ReportedThreads.ToListAsync();
                ReportedThread.Message="These are all the ReportedThreads";
            }
            catch(Exception e){
                ReportedThread.Message=e.Message;
                ReportedThread.Success=false;
                return BadRequest(ReportedThread);
            }
            return Ok(ReportedThread);
        }
        [HttpPost]
        public async Task<IActionResult> AddReportedThread(ReportedThread reportedThread)
        {
          try{
              
          }
          catch(Exception e){

          }
          return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteReportedThread(int id)
        {
            ServiceResponse<List<ReportedThread>> ReportedThread =new ServiceResponse<List<ReportedThread>>();
            try{
                ReportedThread DelReportedThread = await _db.ReportedThreads.FirstOrDefaultAsync();
                _db.ReportedThreads.Remove(DelReportedThread);
                await _db.SaveChangesAsync();
                ReportedThread.Message="ReportedThread has been Deleted";
            }catch(Exception e){
                ReportedThread.Success=false;
                ReportedThread.Message=e.Message;
                return BadRequest();

            }
            return Ok(ReportedThread);
        }
        
    }
}