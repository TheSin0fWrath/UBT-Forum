using backend.Model.Sead;

namespace backend.Model
{
    public class Emails
    {
        public int EmailId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public virtual UserInfo Userid { get; set; }
        public int ToUserId { get; set; }
        public virtual UserInfo ToUser { get; set; }
        public string Message { get; set; }
    }
}