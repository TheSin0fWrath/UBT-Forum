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
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _db;
        public CategoryController(DataContext db)
        {
            _db = db;

        }
        [HttpGet]
        public async Task<IActionResult> getCategory(){
            ServiceResponse<List<Category>> Category = new ServiceResponse<List<Category>>();
         try {
             Category.Data= await _db.Categori.ToListAsync();
             Category.Message="These are all the categoy";
         }
          catch(Exception e){
              Category.Success=false;
              Category.Message=e.Message;
           return BadRequest();
         }
         return Ok(Category);
        }
           [HttpPost]
        public async Task<IActionResult> addCategory(Category newcategory){
            ServiceResponse<List<Category>> Category = new ServiceResponse<List<Category>>();
         try {
         await _db.Categori.AddAsync(newcategory);
         await _db.SaveChangesAsync();
         Category.Message="category has been addeed";
         }
          catch(Exception e){
              Category.Success=false;
              Category.Message=e.Message;
           return BadRequest();
         }
         return Ok(Category);
        }
           [HttpPut]
        public async Task<IActionResult> updateCategory(Category newcategory){
            ServiceResponse<List<Category>> Category = new ServiceResponse<List<Category>>();
         try {
             Category oldcategory =await _db.Categori.FirstOrDefaultAsync(x=>x.CategoryId == newcategory.CategoryId);
             oldcategory.Name = newcategory.Name;
             oldcategory.subCategory = newcategory.subCategory;
             _db.Categori.Update(oldcategory);
         }
          catch(Exception e){
           return BadRequest();
         }
         return Ok(Category);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCategory(int id){
            ServiceResponse<List<Category>> Category = new ServiceResponse<List<Category>>();
         try {
         
          Category delCategory= await _db.Categori.FirstOrDefaultAsync(x=>x.CategoryId == id);
          _db.Categori.Remove(delCategory);
          await _db.SaveChangesAsync();
         }
          catch(Exception e){
           return BadRequest();
         }
         return Ok(Category);
        }
    }
}