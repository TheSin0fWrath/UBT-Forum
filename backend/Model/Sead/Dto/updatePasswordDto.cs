using System.ComponentModel.DataAnnotations;

namespace backend.Model.Sead
{
    public class updatePasswordDto
    {
        [Required(ErrorMessage = "Current Password is required")]
        public string CurrentPassword { get; set; }
        
        [Required(ErrorMessage = "New Password is required")]
        public string Password { get; set; }
        
        
    }
}