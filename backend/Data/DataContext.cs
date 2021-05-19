using backend.Model.Juridik;
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
        public DbSet<VitiPar> JuridikVP { get; set; }
        public DbSet<VParReplay> JuridikVPR { get; set; }
        public DbSet<VitiDyt> JuridikVD { get; set; }
        public DbSet<VDytReplay> JuridikVDR { get; set; }
        public DbSet<VitiTret> JuridikVT { get; set; }
        public DbSet<VTretReplay> JuridikVTR { get; set; }

    }
}