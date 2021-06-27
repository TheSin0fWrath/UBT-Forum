using backend.Model;
using backend.Model.Sead;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public static class ModelBuilderExtension
    {
        public static void seed(this ModelBuilder modelBuilder){
            modelBuilder.Entity<Role>().HasData(
                new Role{
                    Id=1,
                    Name="Admin",
                    Color="#ff0000",
                    Default=false
                },
                 new Role{
                     Id=2,
                    Name="Student",
                    Color="#36dd08",
                    Default=true
                },
                 new Role{
                     
                     Id=3,
                    Name="Profesor",
                    Color="#2283d8",
                    Default=false
                }
            );
             modelBuilder.Entity<Drejtimet>().HasData(
                new Drejtimet{
                    Id=1,
                   Drejtimi="CSE"
                }
            );
             modelBuilder.Entity<Qytetet>().HasData(
                new Qytetet{
                    QytetiId=1,
                   QytetiName="Ferizaj"
                }
            );
             modelBuilder.Entity<Niveli>().HasData(
                new Niveli{
                    Niveli_Id=1,
                   Name="Barchelor"
                }
            );
        }
    }
}