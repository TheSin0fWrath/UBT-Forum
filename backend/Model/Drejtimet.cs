using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Model.Sead;

namespace backend.Model
{
    public class Drejtimet
    {
        
        public int Id{ get; set; }
        public string Drejtimi { get; set; }
        public virtual List<User> user { get; set; }
        public virtual List<Thread> threads { get; set; }
        
        
        
    }
}