using backend.Model.Sead;

namespace backend.Model
{
    public class Warnings
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public int? ByAdminId { get; set; }
        public virtual UserInfo ByAdmin { get; set; }
        public int ToUserId { get; set; }
        public virtual UserInfo ToUser { get; set; }
    }
}