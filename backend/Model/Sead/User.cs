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
        public string Gjenerata { get; set; }
        public string Conntact { get; set; }
        public string ProfilePic { get; set; }
        public int NiveliId { get; set; }
        public virtual Niveli Niveli { get; set; }
        public int DrejtimiId { get; set; }
        public virtual Drejtimet Drejtimi { get; set; }
        public virtual List<Message> Mesages { get; set; }
        public virtual int RoleId { get; set; }
        public virtual List<RoleUser> Role { get; set; }=new List<RoleUser>();
        public virtual  List<Like_Thread> LikeThread { get; set; }
        public virtual  List<ReportedThread> ReportedThreadS { get; set; }
        public virtual  List<ReportedPosts> ReportedPosts { get; set; }

        
    }
}