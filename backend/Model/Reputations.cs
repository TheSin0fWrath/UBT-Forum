using backend.Model.Sead;

namespace backend.Model
{
    public class Reputations
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Reputation { get; set; }

        public int? fromUserId { get; set; }
        public virtual User fromUser { get; set; }
        public int ToUserId { get; set; }
        public virtual User ToUser { get; set; }
    }
}