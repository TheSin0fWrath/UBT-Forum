using System;
using System.Text.Json.Serialization;

namespace backend.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Username  { get; set; }
        public string Text { get; set; }
        
        public string Time { get; set; }
        public int UserId { get; set; }
        
        
         public User User { get; set; }
        
        
        
    }
}