using System.ComponentModel.DataAnnotations;

namespace Chat_System_Using_SignalR_ASP.NET.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Messages { get; set; }
        public string Username { get; set; }
        public string Uid { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Message(string msg, string username, string uid, string? photoUrl)
        {
            Messages = msg;
            Username = username;
            Uid = uid;
            PhotoUrl = photoUrl;
        }

    }
}
