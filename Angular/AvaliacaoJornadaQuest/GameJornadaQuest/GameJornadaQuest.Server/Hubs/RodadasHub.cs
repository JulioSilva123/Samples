using GameJornadaQuest.Server.Data;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using static System.Net.Mime.MediaTypeNames;

namespace GameJornadaQuest.Server.Hubs
{


 

    [HubName("RodadasHub")]
    public class RodadasHub : Hub //<IRodadasHubClient>
    {

        public override Task OnDisconnected(bool stopCalled)
        {
            return Clients.All.leave(Context.ConnectionId, DateTime.Now.ToString());
        }

        public override Task OnConnected()
        {
            return Clients.All.joined(Context.ConnectionId, DateTime.Now.ToString());
        }

        public override Task OnReconnected()
        {
            return Clients.All.rejoined(Context.ConnectionId, DateTime.Now.ToString());
        }

        public void Ping()
        {
            Clients.Caller.pong();
        }


        public async Task SendMensagemRodada(string userName, string message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("mensagemRodada", userName, message);
        }

        public async Task JoinToRodada(string userName, string message, string groupName)
        {
            //await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("JoinedRodada", userName, groupName);
        }

        public async Task SairDaRodada(string userName, string groupName)
        {
           // await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("saiuDaRodada", userName, groupName);
        }

         
    }
}
