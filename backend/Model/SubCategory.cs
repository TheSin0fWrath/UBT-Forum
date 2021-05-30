using backend.Model.Sead;

namespace backend.Model
{
    public class SubCategory
    {
        public int SubId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}