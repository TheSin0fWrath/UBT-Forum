using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Model.Sead;

namespace backend.Model
{
    public class Niveli
    {
        

        
        [Key]
        public int Niveli_Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> users { get; set; }
        public List<Thread> threads { get; set; }
        
    }
}