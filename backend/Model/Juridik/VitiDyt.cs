using System.Collections.Generic;
using backend.Model.Sead;
namespace backend.Model.Juridik
{
    public class VitiDyt
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
       public  List<VDytReplay> VReplay { get; set; } 
}}