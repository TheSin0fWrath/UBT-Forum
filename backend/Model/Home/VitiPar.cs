using backend.Model.Sead;

namespace backend.Model.Home
{
    public class VitiPar
    {
        public int Id { get; set; }
        public string Ttile { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public string Date { get; set; }  
        public int UserId { get; set; }
        public UserInfo User { get; set; }
 
    }
}