using backend.Model.Home;
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
        public DbSet<UserInfo> UsersInfos{ get; set; }
        public DbSet<VitiPar> CSEVP { get; set; }
        public DbSet<VParReplay> CSEVPR { get; set; }
        
    }
}