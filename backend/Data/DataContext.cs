using backend.Model.CSE;
using backend.Model.Sead;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Message> ChatBox { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UsersInfos { get; set; }
        public DbSet<VitiPar> CSEVP { get; set; }
        public DbSet<VparReplay> CSEVPR { get; set; }
        public DbSet<VitiDyt> CSEVD { get; set; }
        public DbSet<VdytReplay> CSEVDR { get; set; }
        public DbSet<VitiTret> CSEVT { get; set; }
        public DbSet<VtretReplay> CSEVTR { get; set; }





    }
}