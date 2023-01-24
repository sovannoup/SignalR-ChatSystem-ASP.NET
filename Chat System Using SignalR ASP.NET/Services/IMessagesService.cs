using Chat_System_Using_SignalR_ASP.NET.Controllers.Request;
using Chat_System_Using_SignalR_ASP.NET.Models;

namespace Chat_System_Using_SignalR_ASP.NET.Services
{
    public interface IMessagesService
    {
        public string SaveMessage(MessageRequest req);
        public List<Message> DeleteMessage(int msgId);
        public Message UpdateMessage(Message msg);
    }
}
