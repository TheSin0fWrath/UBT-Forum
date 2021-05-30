using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Model.Juridik;

namespace backend.Model.Sead
{
    public class UserInfo
    {
        [Required]
        [Key]
         public int UserId { get; set; }
        public User User { get; set; }
        public string Username { get; set; }
        public int  Reputation { get; set; }=0;
        public int  Posts { get; set; }=0;
        public int Likes { get; set; }=0;
        public  int Threads  { get; set; }=0;
        public int  WarningLevel { get; set; }=0;
        public int Credits { get; set; }=0;
        public int ReportedPosts { get; set; }=0;
        public string Gjenerata { get; set; }
        public string Drejtimi { get; set; }
        public string DateOfJoining { get; set; }
        public string Conntact { get; set; }
        public string ProfilePic { get; set; }
        
        public virtual List<ReportedPosts>  ReportedPost { get; set; }
        public virtual List<ReportedThread> ReportedThreads {get; set; }
        public virtual List<Like_Thread> Like_Threads {get; set; }
        public virtual List<Niveli> Nivelis {get; set; }
        public virtual List<Drejtimet> Drejtime {get; set; }
    }
}