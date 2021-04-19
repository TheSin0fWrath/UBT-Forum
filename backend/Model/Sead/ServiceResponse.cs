namespace backend.Model.Sead
{
    public class ServiceResponse <T>
    {
        public string Message { get; set; }
        public  T  Data { get; set; }
        
        public bool Success { get; set; }=true;
        
        
        
    }
}