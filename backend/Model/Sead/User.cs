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
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public bool IsActive { get; set; } = true;
        public string Gjenerata { get; set; }
        public string ProfilePic { get; set; }
        public int? qytetiId { get; set; }
        public Qytetet qyteti { get; set; }
        public int? NiveliId { get; set; }
        public virtual Niveli Niveli { get; set; }
        public int? DrejtimiId { get; set; }
        public virtual Drejtimet Drejtimi { get; set; }
        public virtual List<Message> Mesages { get; set; }
          public virtual List<RoleUser> Role { get; set; }=new List<RoleUser>();
        public virtual List<Thread> Threads { get; set; }      
        public virtual List<Posts> Posts { get; set; }  
        [InverseProperty("ByAdmin")]
        public virtual List<Warnings> ByAdminWarning { get; set; }
        [InverseProperty("ToUser")]
        public virtual List<Warnings> ToUserWarning { get; set; }
        public virtual List<Like_Thread> LikeThread { get; set; }
        public virtual List<ReportedThread> ReportedThreadS { get; set; }
        public virtual List<ReportedPosts> ReportedPosts { get; set; }
        [InverseProperty("sentBy")]
        public virtual List<Emails> sentEmail { get; set; }
        [InverseProperty("recivedBy")]
        public virtual List<Emails> recivedEmail { get; set; }
        public virtual List<Replays> Replays { get; set; }
    }
}