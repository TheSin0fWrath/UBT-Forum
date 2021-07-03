using System.Collections.Generic;
using backend.Model.Sead;
namespace backend.Model

{
    public class Specializimi
    {
       public int SpecializimiId { get; set; } 

       public string SpecializimiText { get; set; }


       public List<User> Users { get; set; }
    }
}