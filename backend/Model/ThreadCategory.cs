using System.ComponentModel.DataAnnotations;
using backend.Model.Sead;

namespace backend.Model
{
    public class ThreadCategory
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual  Category Category  { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual  SubCategory  SubCategory{ get; set; }
        

    }
}