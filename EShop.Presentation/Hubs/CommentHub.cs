using EF_Core;
using EF_Core.Models;
using EShop.Manegers;
using Microsoft.AspNetCore.SignalR;

namespace EShop.Presentation.Hubs
{
    public class CommentHub : Hub
    {
        private readonly CommentManager _CommentManager;

        public CommentHub(CommentManager CommentManager)
        {
            _CommentManager = CommentManager;
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public async Task JoinProductGroup(int productId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Product_{productId}");
        }

        public async Task SendComment(int productId, string userName, string message)
        {
            var comment = new ProductComment
            {
                ProductId = productId,
                UserName = userName,
                Message = message,
                CreatedAt = DateTime.Now
            };

           await _CommentManager.AddAsync(comment);
            //await _context.SaveChangesAsync();

            await Clients.Group($"Product_{productId}")
                .SendAsync("ReceiveComment", userName, message, comment.CreatedAt.ToString("g"));
        }

    }
}
