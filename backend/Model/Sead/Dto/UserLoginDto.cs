using System.ComponentModel.DataAnnotations;

namespace backend.Model.Sead
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        
        
    }
}