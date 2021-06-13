using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Model;
using backend.Model.Sead;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.liza
{
    [ApiController]
    [Route("api/subcategory")]
    public class SubCategoryController : ControllerBase
    {
        private readonly DataContext _db;
        public SubCategoryController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> getSubCategory(){
            ServiceResponse<List<SubCategory>> SubCategory = new ServiceResponse<List<SubCategory>>();
            try{
                SubCategory.Data= await _db.SubCategori.ToListAsync();
                SubCategory.Message="These are all the subcategory";

            }
            catch(Exception e){
            SubCategory.Success=false;
            SubCategory.Message=e.Message;
            return BadRequest();
            }
            return Ok(SubCategory);
        }
         
        [HttpPost]
        public async Task<IActionResult> addSubCategory(SubCategory newsubcategory){
            ServiceResponse<List<SubCategory>> SubCategory = new ServiceResponse<List<SubCategory>>();
            try{
               await _db.SubCategori.AddAsync(newsubcategory);
               await _db.SaveChangesAsync();
               SubCategory.Message="subcategory has been added ";

            }
            catch(Exception e){
            SubCategory.Success=false;
            SubCategory.Message=e.Message;
            return BadRequest();
            }
            return Ok(SubCategory);
        }
         
        [HttpPut]
        public async Task<IActionResult> updateSubCategory(SubCategory newsubcategory){
            ServiceResponse<List<SubCategory>> SubCategory = new ServiceResponse<List<SubCategory>>();
            try{
               SubCategory oldsubcategory =await _db.SubCategori.FirstOrDefaultAsync(x=>x.SubId == newsubcategory.SubId);
                 oldsubcategory.Name = newsubcategory.Name;
        
                   
                _db.SubCategori.Update(oldsubcategory);
            }
            catch(Exception e){
            SubCategory.Success=false;
            SubCategory.Message=e.Message;
            return BadRequest();
            }
            return Ok(SubCategory);
        }
          [HttpDelete("{id}")]
        public async Task<IActionResult> deleteSubCategory(int id){
            ServiceResponse<List<SubCategory>> SubCategory = new ServiceResponse<List<SubCategory>>();
         try {
         
          SubCategory delSubCategory= await _db.SubCategori.FirstOrDefaultAsync(x=>x.SubId == id);
          _db.SubCategori.Remove(delSubCategory);
          await _db.SaveChangesAsync();
         }
          catch(Exception e){
           return BadRequest();
         }
         return Ok(SubCategory);
        }

    }
}