using System.ComponentModel.DataAnnotations;

namespace backend.Model.Sead
{
    public class UserRegisterDto
    {

        [Required(ErrorMessage = "Email is required")]
         public string Email { get; set; }
         [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Drejtimi is required")]
        public int Drejtimi { get; set; }
       
    }
}