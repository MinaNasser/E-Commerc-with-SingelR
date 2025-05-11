using EF_Core;
using EF_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Manegers
{
    public class CommentManager : BaseManager<ProductComment>
    {
        private readonly EShopContext _context;

        public CommentManager(EShopContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductComment> GetCommentsByProductId(int productId, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.ProductComments
                .Where(c => c.ProductId == productId)
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return query.ToList();
        }

        public void AddComment(string userName, string message, int productId)
        {
            var comment = new ProductComment
            {
                UserName = userName,
                Message = message,
                ProductId = productId,
                CreatedAt = DateTime.Now
            };

            _context.ProductComments.Add(comment);
            _context.SaveChanges();
        }
    }
}
