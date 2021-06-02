using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using backend.Model.Sead;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Bleona
{
     [ApiController]
    [Route("api/RepostedPosts")]
    public class RepostedPostsController : ControllerBase
    {    
        private readonly DataContext _db;
        public  RepostedPostsController(DataContext db)
        {
            _db =db;
        }
    
    
        [HttpGet]
public async Task<IActionResult>getRepostedPosts(){
ServiceResonse<List<RepostedPosts>> RepostedPosts = new  ServiceResonse<List<RepostedPosts>>();
try{
RepostedPosts.Data= await _dbRepostedPosts.toListAsync();
RepostedPosts.Message="These are all the ReposttedPosts";
}catch(Exception e){
RepostedPosts.Success=false;
RepostedPosts.Message=e.Message;
return BadRequest((RepostedPosts));
}
return Ok(RepostedPosts);
}
    }
    [HttpPost]
public async Task<IActionResult>add(RepostedPosts newRepostedPosts){
ServiceResonse<List<RepostedPosts>> RepoatedPosts = new  ServiceResonse<List<RepostedPosts>>();
try{
await _db.RepostedPosts.AddAsync(newRepostedPosts);
await _db.SaveChangesAsync();
RepostedPosts.Message="RepostedPosts has been added";
}catch(Exception e){
RepostedPosts.Success=false;
RepostedPosts.Message=e.Message;
return BadRequest((ReportedPosts));
}
return Ok(reportedPosts);
}
[HttpPut]
public async Task<IActionResult>add(RepostedPosts newRepostedPosts){
ServiceResonse<List<RepostedPosts>> RepostedPosts = new  ServiceResonse<List<RepostedPosts>>();

try{
ReportedPosts oldReportedPosts= _db.ReportedPosts.ForstOrDefauldAsync(x=>x.Id == newRepostedPosts.Id);
oldReportedPost.name=newReportedPosts.name;
_db.ReportedPost.Update(oldreportedposts);

}catch(Exception e){
    RepostedPosts.Success=false;
RepostedPosts.Message=e.Message;
return BadRequest((ReportedPosts));

}
return Ok(RepostedPosts);
}
[HttpDelete("{id}")]
public async Task<IActionResult>deleteRepostedPosts(int id){
ServiceResonse<List<RepostedPosts>> RepostedPosts = new  ServiceResonse<List<RepostedPosts>>();
try{
repostedposts delRepostedPosts= await _db.RepostedPosts.FirstOrdDefault(x=>x.Id ==id);
_db.RepostedPosts.Remove(delReostedPosts);
}catch(Exception e){
return BadRequest(RepostedPosts);
}
return Ok(RepostedPosts);
}
}
