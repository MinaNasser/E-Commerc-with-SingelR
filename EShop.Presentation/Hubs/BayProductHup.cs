using Microsoft.AspNetCore.SignalR;

namespace EShop.Presentation.Hubs
{
    public class BayProductHup:Hub
    {

        public override async Task OnConnectedAsync()
        {
            //all Connected  
           await Clients.All.SendAsync("BayProduct");
            //Console.WriteLine($"Client connected: {Context.ConnectionId}");
            //return base.OnConnectedAsync();
        } 
    }
}
