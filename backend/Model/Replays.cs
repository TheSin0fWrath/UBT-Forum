using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Model.Sead;

namespace backend.Model
{
    public class Replays
    {
        [Key]
        public int ReplayId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
         [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int EmailId { get; set; }
        public virtual Emails Email { get; set; }
        
        
    }
}