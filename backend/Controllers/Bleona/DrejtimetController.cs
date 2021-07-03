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
    [Route("api/Drejtimet")]   
    public class DrejtimetController : ControllerBase
    {
        private readonly DataContext _db;
        public DrejtimetController(DataContext db)
        {
            _db =db;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrejtimet()
        {
            ServiceResponse<List<Drejtimet>> Drejtimet = new ServiceResponse<List<Drejtimet>>();
            try{
                Drejtimet.Data=await _db.Drejtime.ToListAsync();
                Drejtimet.Message="These are all Courses";
            } 
            catch(Exception e){
                Drejtimet.Success=false;
                Drejtimet.Message=e.Message;
                return BadRequest(Drejtimet);
            }
            return Ok(Drejtimet);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDrejtimet(Drejtimet newDrejtimet)
        {
             ServiceResponse<List<Drejtimet>> Drejtimet =new ServiceResponse<List<Drejtimet>>();
            try{
                await _db.Drejtime.AddAsync(newDrejtimet);
                await _db.SaveChangesAsync();
                Drejtimet.Message="Course has been Added";
            }catch(Exception e){
                Drejtimet.Success=false;
                Drejtimet.Message=e.Message;
                return BadRequest((Drejtimet));
            }
            return Ok(Drejtimet);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDrejtimet(Drejtimet newDrejtimet)
        {
            ServiceResponse<List<Drejtimet>> Drejtimet =new ServiceResponse<List<Drejtimet>>();
            try{
                Drejtimet oldDrejtimet=await _db.Drejtime.FirstOrDefaultAsync();
                oldDrejtimet.Drejtimi=newDrejtimet.Drejtimi;
                _db.Drejtime.Update(oldDrejtimet);
                await _db.SaveChangesAsync();
                Drejtimet.Message="Course has been Updated";
            }catch(Exception e){
                Drejtimet.Success=false;
                Drejtimet.Message=e.Message;
                return BadRequest();
            }
            return Ok(Drejtimet);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrejtimet ( int id){
            ServiceResponse<List<Drejtimet>> Drejtimet = new ServiceResponse<List<Drejtimet>>();
            try{
                Drejtimet delDrejtimet= await _db.Drejtime.FirstOrDefaultAsync(x=>x.Id == id);
                _db.Drejtime.Remove(delDrejtimet);
                await _db.SaveChangesAsync();
                Drejtimet.Message="Course has been Deleted";
            }catch(Exception e){
                Drejtimet.Success=false;
                Drejtimet.Message=e.Message;
                return BadRequest();
            }
            return Ok (Drejtimet);
        }
       
    }
}