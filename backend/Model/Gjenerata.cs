using System.Collections.Generic;
using backend.Model.Sead;

namespace backend.Model
{
    public class Gjenerata
    {
        public int GjenerataId { get; set; }
        public string GjenerataText { get; set;}

        public List<User> Users { get; set; }
    }
}