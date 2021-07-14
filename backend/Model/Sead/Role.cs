using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Model.Sead
{
    public class Role
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }
        public string Date { get; set; }
        [Required(ErrorMessage = "Role Color is required")]

        public string Color { get; set; } 
        public bool Default { get; set; }

        public virtual List<RoleUser> roleUser { get; set; }
        
        
        
         
    }
}