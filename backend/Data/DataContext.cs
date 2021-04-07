using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
  
        public DbSet<Message> ChatBox { get; set; }
        public DbSet<User>  Users{ get; set; }
        
        

    }
}