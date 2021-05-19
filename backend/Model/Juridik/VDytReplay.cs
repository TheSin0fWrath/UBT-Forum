using backend.Model.Sead;
namespace backend.Model.Juridik
{
    public class VDytReplay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }=0;
        public string Date { get; set; }
        public int ThreadId { get; set; }
        public VitiDyt Thread { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
    }
}