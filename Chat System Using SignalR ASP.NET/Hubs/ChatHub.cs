using Chat_System_Using_SignalR_ASP.NET.Controllers.Request;
using Chat_System_Using_SignalR_ASP.NET.Models;
using Chat_System_Using_SignalR_ASP.NET.Services;
using Microsoft.AspNetCore.SignalR;

namespace Chat_System_Using_SignalR_ASP.NET.Hubs
{
    public class Chathub : Hub
    {
        private readonly string _user;
        private readonly IMessagesService _messagesService;
        private readonly IDictionary<string, ChatUserConnection> _connections;

        public Chathub(IDictionary<string, ChatUserConnection> connections, IMessagesService messagesService)
        {
            _user = "Bot User";
            _messagesService = messagesService;
            _connections = connections;
        }


        public async Task SendMessage(MessageRequest req)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out ChatUserConnection? userConnection))
            {
                Console.WriteLine("Message in server is : " + req.Messages);
                _messagesService.SaveMessage(req);
                await Clients.Group(userConnection.roomChannel()).SendAsync("ReceiveMessage", userConnection.Username, req.Messages);
            }
        }


        public async Task JoinedRoom(ChatUserConnection chatUserConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatUserConnection.roomChannel());
            _connections[Context.ConnectionId] = chatUserConnection;
            await Clients.Group(chatUserConnection.RoomName).SendAsync("ReceiveMessage", _user, $"{chatUserConnection.Username} has joined {chatUserConnection.RoomName}");
            await SendUsersConnected(chatUserConnection.roomChannel());
        }

        public Task SendUsersConnected(string room)
        {
            var users = _connections.Values
                .Where(c => c.roomChannel() == room)
                .Select(c => c.Username);

            return Clients.Group(room).SendAsync("UsersInRoom", users);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out ChatUserConnection? userConnection))
            {
                _connections.Remove(Context.ConnectionId);
                Clients.Group(userConnection.RoomName).SendAsync("ReceiveMessage", _user, $"{userConnection.Username} has left");
                SendUsersConnected(userConnection.RoomName);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
