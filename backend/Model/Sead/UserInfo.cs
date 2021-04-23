using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Model.Home;

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
        public List<VitiPar> CseVP { get; set; }
        public List<VParReplay> CseVPR { get; set; }
        
        
        
        
        
    }
}