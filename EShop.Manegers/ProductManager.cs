using EF_Core;
using EF_Core.Models;
using EShop.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;

namespace EShop.Manegers
{
    public class ProductManager : BaseManager<Product>
    {
        public ProductManager(EShopContext db) : base(db)
        {

        }
        public PaginationViewModel<ProductDetailsViewModel> Search(
            string searchText = "", decimal price = 0,
            int categoryId = 0, string vendorId = "", int pageNumber = 1,
            int pageSize = 4)
        {

            var builder = PredicateBuilder.New<Product>();

            var old = builder;

            if (!searchText.IsNullOrEmpty())
                builder = builder.And(i => i.Name.ToLower().Contains(searchText.ToLower()) || i.Description.ToLower().Contains(searchText.ToLower()));

            if (price > 1)
                builder = builder.And(i => i.Price <= price);

            if (!vendorId.IsNullOrEmpty())
                builder = builder.And(i => i.VendorId == vendorId);

            if (categoryId > 0)
                builder = builder.And(i => i.CategoryId == categoryId);



            builder = builder.And(i => i.IsDelated == false);

            if (old == builder)
                builder = null;



            var count = base.GetList(builder).Count();

            var resultAfterPagination = base.Get(
                filter: builder,
                pageSize: pageSize,
                pageNumber: pageNumber)
                .Select(p => p.ToDetailsVModel()).ToList();

            return new PaginationViewModel<ProductDetailsViewModel>
            {
                Data = resultAfterPagination,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Total = count
            };

        }


        public async Task<bool> ReduceStockAsync(int productId, int quantity)
        {
            var product = await table.FindAsync(productId);
            if (product == null || product.Quantity < quantity)
                return false;

            product.Quantity -= quantity;
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> GetQuantityAsync(int productId)
        {
            var product = table.FirstOrDefault(p => p.Id == productId);
            return product?.Quantity ?? 0;
        }



    }
}
