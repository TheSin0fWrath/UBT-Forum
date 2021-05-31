using backend.Model.Sead;

namespace backend.Model
{
    public class Posts
    {
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }

        
    }
}