using EF_Core;
using EF_Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace EShop.Presentation.Hubs
{
    public class CommentHub : Hub
    {
        private readonly EShopContext _context;

        public CommentHub(EShopContext context)
        {
            _context = context;
        }

        public async Task JoinProductGroup(int productId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Product_{productId}");
        }

        public async Task SendComment(int productId, string userName, string message)
        {
            if (string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(userName))
                return;

            var comment = new ProductComment
            {
                ProductId = productId,
                UserName = userName,
                Message = message,
                CreatedAt = DateTime.Now
            };

            _context.ProductComments.Add(comment);
            await _context.SaveChangesAsync();

            await Clients.Group($"Product_{productId}")
                .SendAsync("ReceiveComment", userName, message, comment.CreatedAt.ToString("g"));
        }
    }
}
