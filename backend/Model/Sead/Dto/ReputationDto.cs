namespace backend.Model.Sead.Dto
{
    public class ReputationDto
    {
        public int id { get; set; }
        
        public int? touser { get; set; }
        
        public int? fromuser { get; set; }
        public string username { get; set; }
        public int points { get; set; }
        public string message { get; set; }
        
        
      
    }
}