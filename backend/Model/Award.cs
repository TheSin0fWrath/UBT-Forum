using System.Collections.Generic;

namespace backend.Model
{
    public class Award
    
    {
        public int Id { get; set; }
        
        public string AwardText { get; set; }
        public List<AwardUser> Awards { get; set; }
        
    }
}