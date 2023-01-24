using Chat_System_Using_SignalR_ASP.NET.Controllers.Request;
using Chat_System_Using_SignalR_ASP.NET.DatabaseContext;
using Chat_System_Using_SignalR_ASP.NET.Models;

namespace Chat_System_Using_SignalR_ASP.NET.Services
{
    public class MessageServices : IMessagesService
    {
        private readonly ApplicationDbContext _context;
        public MessageServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Message> DeleteMessage(int msgId)
        {
            throw new NotImplementedException();
        }

        public string SaveMessage(MessageRequest req)
        {
            Console.WriteLine("Message " + req.Messages);
            Message msg = new(req.Messages, req.Username, req.Uid, req.PhotoUrl);
            _context.Messages.Add(msg);
            _context.SaveChanges();
            return "Success";
        }

        public Message UpdateMessage(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
