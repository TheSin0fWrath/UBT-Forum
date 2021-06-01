using backend.Model.Sead;

namespace backend.Model
{
    public class Niveli
    {
        public int Niveli_Id { get; set; }
        public string Name { get; set; }
        public virtual User user { get; set; }
        
        
    }
}