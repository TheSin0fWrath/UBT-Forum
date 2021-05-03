namespace backend.Model.Sead
{
    public class UserInfoDto
    {
      
         public int UserId { get; set; }
        public string Username { get; set; }
        public int  Reputation { get; set; }=0;
        public int Likes { get; set; }=0;
        public  int Threads  { get; set; }=0;
        public string Gjenerata { get; set; }
        public string Drejtimi { get; set; }
        public string ProfilePic { get; set; }
    }
}