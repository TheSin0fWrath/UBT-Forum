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
    [Route("api/Niveli")]
    public class NiveliController : ControllerBase
    {
        private readonly DataContext _db;
        public NiveliController(DataContext db)
        {
            _db =db;
        }

        [HttpGet]
        public async Task<IActionResult> GetNiveli()
        {
            ServiceResponse<List<Niveli>> Niveli = new ServiceResponse<List<Niveli>>();
            try{
                Niveli.Data=await _db.Nivelis.ToListAsync();
                Niveli.Message="These are all the Academic Degrees";
            }
            catch(Exception e){
                Niveli.Success=false;
                Niveli.Message=e.Message;
                return BadRequest(Niveli);
            }
            return Ok(Niveli);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNiveli(Niveli newNiveli)
        {
            ServiceResponse<List<Niveli>> Niveli = new ServiceResponse<List<Niveli>>();
            try{
                await _db.Nivelis.AddAsync(newNiveli);
                await _db.SaveChangesAsync();
                Niveli.Message="Academic Degree has been Added";
            }catch(Exception e){
                Niveli.Success=false;
                Niveli.Message=e.Message;
                return BadRequest((Niveli));
            }
            return Ok(Niveli);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateNiveli(Niveli newNiveli){
            ServiceResponse<List<Niveli>> Niveli = new ServiceResponse<List<Niveli>>();
            try{
                Niveli oldNiveli = await _db.Nivelis.FirstOrDefaultAsync();
                oldNiveli.Name=newNiveli.Name;
                _db.Nivelis.Update(oldNiveli);
                Niveli.Message="Academic Degree has been Updated";
                 await _db.SaveChangesAsync();
            }catch(Exception e){
                Niveli.Success=false;
                Niveli.Message=e.Message;
                return BadRequest();
            }
            return Ok(Niveli);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNiveli ( int id){
            ServiceResponse<List<Niveli>> Niveli = new ServiceResponse<List<Niveli>>();
            try{
                Niveli delNiveli =await _db.Nivelis.FirstOrDefaultAsync(x=>x.Niveli_Id == id);
                _db.Nivelis.Remove(delNiveli);
                await _db.SaveChangesAsync();
                Niveli.Message="Academic Degree has been Deleted";
            }catch(Exception e){
                Niveli.Success=false;
                Niveli.Message=e.Message;
                return BadRequest();
            }
            return Ok(Niveli);
        }
    }
}