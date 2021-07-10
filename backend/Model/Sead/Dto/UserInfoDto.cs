namespace backend.Model.Sead
{
    public class UserInfoDto
    {
      
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public bool IsActive { get; set; }
        public int  Posts { get; set; }
        public int Reputation { get; set; }
        public int Likes { get; set; }
        public  int Threads  { get; set; }
        public int  WarningLevel { get; set; }
        public int ReportedPosts { get; set; }
        public string Gjenerata { get; set; }
        public string Drejtimi { get; set; }
        public string ProfilePic { get; set; }
        public dynamic Role { get; set; }
    }
}