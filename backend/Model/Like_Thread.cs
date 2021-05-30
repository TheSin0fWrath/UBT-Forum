namespace backend.Model
{
    public class Like_Thread
    {
        [key]
        public int UserId { get; set; }
        [key]
        public int ThreadId { get; set; }
    }
}