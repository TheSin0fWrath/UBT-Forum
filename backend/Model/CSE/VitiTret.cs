using System.Collections.Generic;
using backend.Model.Sead;
namespace backend.Model.CSE
{
    public class VitiTret
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; } = 0;
        public string Date { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }

        public List<VtretReplay> Replays { get; set; }
    }
}