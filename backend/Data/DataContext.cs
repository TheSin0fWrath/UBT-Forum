

using backend.Model;
using  backend.Model.Sead;
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
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUser { get; set; }    
        public DbSet<ReportedPosts> ReportedPost { get; set; }
        public DbSet<ReportedThread> ReportedThreads {get; set; }
        public DbSet<Like_Thread> Like_Threads {get; set; }
        public DbSet<Niveli> Nivelis {get; set; }
        public DbSet<Drejtimet> Drejtime {get; set; }
        public DbSet<Posts> Post { get; set; }
       public DbSet<Thread> Threads { get; set; }
       public DbSet<ThreadCategory> ThreadCategori { get; set; }
        public DbSet<Category> Categori { get; set; }
        public DbSet<SubCategory> SubCategori { get; set; }







    }
}