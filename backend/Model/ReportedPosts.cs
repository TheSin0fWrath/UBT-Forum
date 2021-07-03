using System.ComponentModel.DataAnnotations;
using backend.Model.Sead;

namespace backend.Model
{
    public class ReportedPosts
    {
        public static string Message { get; internal set; }
        [Key]
        public int ReportedId { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public virtual Posts Post { get; set; }
        public int? userId { get; set; }
        public virtual  User  user{ get; set; }

    }
}