using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using backend.Model.Sead;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.Albin



{
     [ApiController]
    [Route("api/specializimi")]
    public class SpecializimiController : ControllerBase
    {
        private readonly DataContext _db;
        public SpecializimiController (DataContext db)
        {
            _db = db;
        }
        [HttpGet]

        public async Task<IActionResult> getSpecializime () 
        {
            ServiceResponse<List<Specializimi>> response = new ServiceResponse<List<Specializimi>>();
            try{
                response.Data = await _db.Specializime.ToListAsync();
            } catch(Exception e){
                response.Success = false;
                response.Message = e.Message;
                return BadRequest (response);
            }
            return Ok(response);
        }
         [HttpPost]
        
        public async Task<IActionResult> addSpecializime(Specializimi newresponse)
        {
            ServiceResponse<List<Specializimi>> response = new ServiceResponse<List<Specializimi>>();
            try{
                await _db.Specializime.AddAsync(newresponse);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.Success = false ;
                response.Message = e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]

        public async Task<IActionResult> updateSpecializime(Specializimi newresponse)
        {
            ServiceResponse<List<Specializimi>> response = new ServiceResponse<List<Specializimi>>();
            try {
                Specializimi oldresponse = await _db.Specializime.FirstOrDefaultAsync (x => x.SpecializimiId == newresponse.SpecializimiId);
                oldresponse.SpecializimiId = newresponse.SpecializimiId;
                _db.Specializime.Update(oldresponse);
                await _db.SaveChangesAsync();
            }
            catch (Exception e){
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteSpecializime (int id){
            ServiceResponse<List<Specializimi>> response = new ServiceResponse<List<Specializimi>>();
            try {
                Specializimi delSpecializimi = await _db.Specializime.FirstOrDefaultAsync (x => x.SpecializimiId == id);
                _db.Specializime.Remove(delSpecializimi);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}