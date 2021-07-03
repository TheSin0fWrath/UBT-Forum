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
    [Route("api/gjenerata")]
    public class GjenerataController : ControllerBase 
{
    private readonly DataContext _db;
    public GjenerataController(DataContext db)
    {
         _db = db;
    }
     [HttpGet]

     public async Task<IActionResult> getGjeneratat()
    {
        ServiceResponse<List<Gjenerata>> gjeneratat = new ServiceResponse<List<Gjenerata>>();
        try 
        {
            gjeneratat.Data = await _db.Gjeneratat.ToListAsync();
        }
        catch (Exception e)
        {
            gjeneratat.Success = false;
            gjeneratat.Message = e.Message;
            return BadRequest(gjeneratat);
        }
        return Ok(gjeneratat);
    }
    [HttpPost]

    public async Task<IActionResult> addGjeneratat(Gjenerata newgjeneratat)
    {
        ServiceResponse<List<Gjenerata>> gjeneratat = new ServiceResponse<List<Gjenerata>>();
        try {
            await _db.Gjeneratat.AddAsync(newgjeneratat);
            await _db.SaveChangesAsync();
        }
        catch(Exception e)
        {
            gjeneratat.Success = false ;
            gjeneratat.Message = e.Message;
            return BadRequest (gjeneratat);
        }
        return Ok(gjeneratat);
    }
    [HttpPut]
    public async Task<IActionResult> updateGjeneratat(Gjenerata newgjeneratat)
    {
        ServiceResponse<List<Gjenerata>> response = new ServiceResponse<List<Gjenerata>>();
        try {
            Gjenerata oldgjeneratat = await _db.Gjeneratat.FirstOrDefaultAsync (x => x.GjenerataId == newgjeneratat.GjenerataId);
            oldgjeneratat.GjenerataId = newgjeneratat.GjenerataId;
            _db.Gjeneratat.Update(oldgjeneratat);
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
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteGjeneratat (int id)
    {
        ServiceResponse<List<Gjenerata>> gjeneratat = new ServiceResponse<List<Gjenerata>>();
        try {
              Gjenerata delGjenerata = await _db.Gjeneratat.FirstOrDefaultAsync(x => x.GjenerataId == id);
              _db.Gjeneratat.Remove(delGjenerata);
              await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            gjeneratat.Success = false;
            gjeneratat.Message = e.Message;
            return BadRequest(gjeneratat);

        }
       return Ok(gjeneratat);
    }
    }}
