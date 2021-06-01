using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Model.Sead;

namespace backend.Model
{
    public class Like_Thread
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Key, Column(Order = 1)]
        public int ThreadId { get; set; }
        public virtual Thread Thread { get; set; }
        
        
    }
}