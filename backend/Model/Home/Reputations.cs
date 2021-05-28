using backend.Model.Sead;

namespace backend.Model.Home
{
    public class Reputations
    {
        public int  Id { get; set; }
        public string Message { get; set; }
        public int Reputation { get; set; }
        public int fromUserId { get; set; }
        public virtual UserInfo fromUser { get; set; }
        public int toUserId { get; set; }
        public virtual UserInfo toUser{get; set;}
    }
}

