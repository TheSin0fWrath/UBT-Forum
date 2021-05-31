using backend.Model.Sead;

namespace backend.Model
{
    public class Replays
    {
        public int ReplayId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int EmailFkId { get; set; }
        public virtual User EmailFk { get; set; }
    }
}