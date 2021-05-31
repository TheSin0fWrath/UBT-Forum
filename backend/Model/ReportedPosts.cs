namespace backend.Model
{
    public class ReportedPosts
    {
        public int ReportedId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int userId { get; set; }
        public virtual  UserInfo  user{ get; set; }

    }
}