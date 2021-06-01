using backend.Model.Sead;

namespace backend.Model
{
    public class Drejtimet
    {
        public int DrejtimiId{ get; set; }
        public string Drejtimi { get; set; }
        public virtual User user { get; set; }
        
        
    }
}