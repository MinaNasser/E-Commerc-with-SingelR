using EF_Core;
using EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace EShop.Manegers
{
    public class CommentManager : BaseManager<ProductComment>
    {
        private readonly EShopContext _dbContext;

        public CommentManager(EShopContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<ProductComment> GetCommentsByProductId(int productId, int pageSize = 10, int pageNumber = 1)
        {
            var query = _dbContext.ProductComments
                .Where(c => c.ProductId == productId)
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return query.ToList();
        }

        public async Task AddAsync(ProductComment comment)
        {
            await _dbContext.ProductComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

    }
}
