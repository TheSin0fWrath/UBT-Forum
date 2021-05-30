using backend.Model.Sead;

namespace backend.Model
{
    public class ThreadCategory
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public virtual  Thread Thread   { get; set; }
        public int CategoryId { get; set; }
        public virtual  Category Category  { get; set; }
        public int SubCategoryId { get; set; }
        public virtual  SubCategory  SubCategory{ get; set; }
        

    }
}