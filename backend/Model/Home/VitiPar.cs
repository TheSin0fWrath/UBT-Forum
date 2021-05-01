using System.Text.Json.Serialization;
using backend.Model.Sead;

namespace backend.Model.Home
{
    public class VitiPar
    {
        public int Id { get; set; }
        public string Ttile { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }=0;
        public string Date { get; set; }  
        public int UserId { get; set; }
        [JsonIgnore]
        public UserInfo User { get; set; }
 
    }
}