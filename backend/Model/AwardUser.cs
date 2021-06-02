using backend.Model.Sead;
namespace backend.Model
{
    public class AwardUser
    {
        public int Id { get; set; }
        public int UserFk { get; set; }
        public User User { get; set; }
        public int AwardId { get; set; }
        public Award Award { get; set; }
    }   

}