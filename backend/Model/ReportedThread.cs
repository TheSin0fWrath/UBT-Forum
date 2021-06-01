using backend.Model.Sead;

namespace backend.Model
{
    public class ReportedThread
    {
        public int ReportId { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
        public int UserId { get; set; }
        public virtual User User {get; set; }
        
    }
}