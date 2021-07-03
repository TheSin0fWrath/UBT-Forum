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
    [Route("api/Like_Thread")]
    public class Like_ThreadController : ControllerBase
    {
        private readonly DataContext _db;
        public Like_ThreadController(DataContext db)
        {
            _db =db;
        }
        [HttpGet]
        public async Task<IActionResult>GetLike_Thread()
        {
            ServiceResponse<List<Like_Thread>> Like_Thread =new ServiceResponse<List<Like_Thread>>();
            try{
                Like_Thread.Data=await _db.Like_Threads.ToListAsync();
                Like_Thread.Message="These are all Like_Threads";
            }
            catch(Exception e){
                Like_Thread.Message=e.Message;
                Like_Thread.Success=false;
                return BadRequest(Like_Thread);
            }
            return Ok(Like_Thread);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteLike_Thread (int id){
            ServiceResponse<List<Like_Thread>> Like_Thread = new ServiceResponse<List<Like_Thread>>();
            try{
                Like_Thread delLike_Thread=await _db.Like_Threads.FirstOrDefaultAsync();
                _db.Like_Threads.Remove(delLike_Thread);
                await _db.SaveChangesAsync();

            }catch(Exception e){
                Like_Thread.Success=false;
                Like_Thread.Message=e.Message;
                return BadRequest();
            }
            return Ok(Like_Thread);

        }
       
    }
}