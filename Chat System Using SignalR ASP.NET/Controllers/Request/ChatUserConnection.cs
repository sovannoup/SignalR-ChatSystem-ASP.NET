using System.ComponentModel.DataAnnotations;

namespace Chat_System_Using_SignalR_ASP.NET.Controllers.Request
{
    public class ChatUserConnection
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public string ServerName { get; set; }

        public string roomChannel()
        {
            return ServerName + "-" + RoomName;
        }
    }
}
