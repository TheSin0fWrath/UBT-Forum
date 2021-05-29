using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public virtual List<Message> Mesages { get; set; }
        public virtual UserInfo UserInfo { get; set;} = new UserInfo();

        
        
        
        
        
        
    }
}