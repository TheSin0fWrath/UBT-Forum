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
    [Route("api/ReportedPosts")]
    public class ReportedPostsController : ControllerBase 
    {
        private readonly DataContext _db;
        public ReportedPostsController(DataContext db)
        {
            _db =db;
        }

        [HttpGet]
        public async Task<IActionResult>GetReportedPosts()
        {
           ServiceResponse<List<ReportedPosts>> ReportedPosts = new ServiceResponse<List<ReportedPosts>>();
           try{
               ReportedPosts.Data=await _db.ReportedPost.ToListAsync();
               ReportedPosts.Message="These are all Reported Posts";
           }catch(Exception e){
               ReportedPosts.Message=e.Message;
               ReportedPosts.Success=false;
               return BadRequest(ReportedPosts);
           }
           return Ok(ReportedPosts);
        }
        [HttpPost]
        public async Task<IActionResult> AddReportPosts(ReportedPosts  reportedPosts)
        {
            ServiceResponse<List<ReportedPosts>> ReportedPosts = new ServiceResponse<List<ReportedPosts>>();
            
            

             try{
                 
                 await _db.ReportedPost.AddAsync(reportedPosts);
                 await _db.SaveChangesAsync();
                ReportedPosts.Message="Reported Post has been Added";

             }catch(Exception e){
                 ReportedPosts.Message=e.Message;
                 return BadRequest((ReportedPosts));
             }
             return Ok(ReportedPosts);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteReportedPosts(int id){
            ServiceResponse<List<ReportedPosts>> ReportedPosts =new ServiceResponse<List<ReportedPosts>>();
            try{
                ReportedPosts delReportedPosts = await _db.ReportedPost.FirstOrDefaultAsync();
                _db.ReportedPost.Remove(delReportedPosts);
                await _db.SaveChangesAsync();
                ReportedPosts.Message="ReportedPost has been Deleted";
            }catch(Exception e){
                ReportedPosts.Success=false;
                ReportedPosts.Message=e.Message;
                return BadRequest();
            }
            return Ok(ReportedPosts);
        }
    }
}