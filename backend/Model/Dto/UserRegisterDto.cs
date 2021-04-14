using System.ComponentModel.DataAnnotations;

namespace backend.Model.Dto
{
    public class UserRegisterDto
    {
         public int Id { get; set; }
         [Required]
         public string Email { get; set; }
         [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string DateOfJoining { get; set; }
        [Required]
        public string Gjenerata { get; set; }
        [Required]
     
        public string Drejtimi { get; set; }
       
    }
}