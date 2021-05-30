using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model.Sead
{
    public class UserInfo
    {

        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        public string Username { get; set; }
        public int Posts { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Threads { get; set; } = 0;
        public int WarningLevel { get; set; } = 0;
        public int Credits { get; set; } = 0;
        public int ReportedPosts { get; set; } = 0;
        public string Gjenerata { get; set; }
        public string Drejtimi { get; set; }
        public string DateOfJoining { get; set; }
        public string Conntact { get; set; }
        public string ProfilePic { get; set; }
        [InverseProperty("toUserWarning")]
        public virtual List<Warnings> toUserWarning { get; set; }
        public virtual List<Warnings> fromUserWarning { get; set; }
        [InverseProperty("toUserReputation")]
        public virtual List<Reputations> toUserReputation { get; set; }
        public virtual List<Reputations> fromUserReputation { get; set; }

        public virtual List<Emails> Email { get; set; }
        public virtual List<Replays> Replay { get; set; }
    }
}
