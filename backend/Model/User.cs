using System.Collections.Generic;

namespace backend.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[]  PasswordHash { get; set; }
        public byte[]  PasswordSalt { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public bool IsActive { get; set; }=true;
        public List<Message> Mesages { get; set; }
        
        public UserInfo UserInfo { get; set;} = new UserInfo();

        
        
        
        
        
        
    }
}