using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model.Sead
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public byte[]  PasswordHash { get; set; }
        public byte[]  PasswordSalt { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public bool IsActive { get; set; }=true;
        public int  Posts { get; set; }=0;
        public int Likes { get; set; }=0;
        public  int Threads  { get; set; }=0;
        public int  WarningLevel { get; set; }=0;
        public int Credits { get; set; }=0;
        public int ReportedPosts { get; set; }=0;
        public string Gjenerata { get; set; }
        public string Drejtimi { get; set; }
        public string Conntact { get; set; }
        public string ProfilePic { get; set; }
        public virtual List<Message> Mesages { get; set; }
        public virtual int RoleId { get; set; }
        public virtual List<RoleUser> Role { get; set; }=new List<RoleUser>();
    }
}