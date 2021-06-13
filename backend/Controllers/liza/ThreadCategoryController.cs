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
    [Route("api/threadcategory")]

    
    public class ThreadCategoryController : ControllerBase
    {
        private readonly DataContext _db;
        public ThreadCategoryController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> getThreadCategory(){
            ServiceResponse<List<ThreadCategory>> ThreadCategory = new ServiceResponse<List<ThreadCategory>>();
            try{

                ThreadCategory.Data= await _db.ThreadCategori.ToListAsync();
                ThreadCategory.Message= "These are all the thread category";
            }
            catch(Exception e){
             ThreadCategory.Success=false;
             ThreadCategory.Message=e.Message;
             return BadRequest();
            }
            return Ok(ThreadCategory);
            
        }
        [HttpPost]
        public async Task<IActionResult> addThreadCategory(ThreadCategory newthreadcategory){
        ServiceResponse<List<ThreadCategory>> ThreadCategory = new ServiceResponse<List<ThreadCategory>>();
        try {
           await _db.ThreadCategori.AddAsync(newthreadcategory);
           await _db.SaveChangesAsync();
           ThreadCategory.Message = "threadcategory has been added";

          
        }
        catch(Exception e){
        ThreadCategory.Success=false;
        ThreadCategory.Message=e.Message;
        return BadRequest();
        }
        return Ok(ThreadCategory);
    }
    [HttpPut]
    public async Task<IActionResult> updateThreadCategory (ThreadCategory newthreadcategory){
        ServiceResponse<List<ThreadCategory>> ThreadCategory = new ServiceResponse<List<ThreadCategory>>();
        try{
               ThreadCategory oldthreadcategory =await _db.ThreadCategori.FirstOrDefaultAsync(x=>x.Id == newthreadcategory.Id);
            oldthreadcategory.SubCategoryId= newthreadcategory.SubCategoryId;
            oldthreadcategory.CategoryId= newthreadcategory.CategoryId;
            
            _db.ThreadCategori.Update(oldthreadcategory);
        }
        catch(Exception e){
            return BadRequest();

        }
        return Ok(ThreadCategory);


    }
     [HttpDelete("{id}")]
        public async Task<IActionResult> deleteThreadCategory(int id){
            ServiceResponse<List<ThreadCategory>> ThreadCategory = new ServiceResponse<List<ThreadCategory>>();
         try {
         
          ThreadCategory delThreadCategory= await _db.ThreadCategori.FirstOrDefaultAsync(x=>x.CategoryId == id);
          _db.ThreadCategori.Remove(delThreadCategory);
          await _db.SaveChangesAsync();
         }
          catch(Exception e){
           return BadRequest();
         }
         return Ok(ThreadCategory);
        }

}
}