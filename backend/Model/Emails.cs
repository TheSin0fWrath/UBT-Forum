using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Model.Sead;

namespace backend.Model
{
    public class Emails
    {
        [Key]
        public int EmailId { get; set; }
        public string Title { get; set; }
        public virtual User sentBy { get; set; }
        public virtual User recivedBy { get; set; }
        public string Message { get; set; }
        public virtual List<Replays> Replays { get; set; }
        public int ToUserId { get; internal set; }    }
}