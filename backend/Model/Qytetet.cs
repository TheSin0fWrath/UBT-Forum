using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Model.Sead;

namespace backend.Model
{
    public class Qytetet
    {
        [Key]
        public int QytetiId { get; set; }
        public string QytetiName { get; set; }
        public virtual List<User> Users { get; set; }


    }
}