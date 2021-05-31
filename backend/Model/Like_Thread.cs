using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Like_Thread
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int ThreadId { get; set; }
    }
}