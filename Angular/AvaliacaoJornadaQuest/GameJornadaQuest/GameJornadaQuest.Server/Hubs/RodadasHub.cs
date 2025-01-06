using GameJornadaQuest.Server.Data;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using static System.Net.Mime.MediaTypeNames;

namespace GameJornadaQuest.Server.Hubs
{


    //public interface IRodadasHubClient
    //{
    //    //Task SendOffersToUser(List<string> message);
    //    Task SendMsg(string test);

    //    Task leave(bool stopCalled);

    //}




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

        //public async Task AddRodada(Rodadas[] rooms)
        //{
        //    await Clients.All.SendAsync("AddRodada", rooms);
        //}






        //this.hubConService.hubConnection
        //  .invoke('JoinToRodada', this.pessoa.idPessoa, this.rodada.idRodada)
        //  .catch(err => console.log('JoinToRodada :', err));

        //this.hubConService.hubConnection.on('JoinedRodada', async(pessoa: Pessoa, rodada: Rodada) => {
        //  const text = pessoa.nmPessoa + ' Entrou na Rodada ' + rodada.idRodada;

        //  //console.log(text);

        //  this.messages.push(text);
        //});

        //this.hubConService.hubConnection.on('messagedToGroup', async (pessoa: Pessoa, receivedMessage) => {
        //    const text = pessoa.nmPessoa + ': ' + receivedMessage;
        //    this.messages.push(text);
        //});

        //this.hubConService.hubConnection.on('saiuDoGroup', async (pessoa: Pessoa , rodada: Rodada) => {
        //    const text = pessoa.nmPessoa + ' saiu na Rodada ' + rodada.idRodada;
        //    console.log(text);
        //    this.messages.push(text);
        //});










    }
}
