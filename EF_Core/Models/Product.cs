using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public bool IsDelated { get; set; }
        //[NotMapped]
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<ProductAttachment> Attachments { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<CartItem> CartList { get; set; }
        public virtual ICollection<FavoriteItem> FavoriteList { get; set; }

    }

    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder.HasKey(p => p.Id);
            modelBuilder.Property(p => p.Name).HasColumnType("NVARCHAR(100)").IsRequired();
            modelBuilder.Property(p => p.Quantity).HasColumnName("Stock").HasDefaultValue(1);
            modelBuilder.Property(p => p.Price).HasColumnType("Money");
            modelBuilder.Property(p => p.Description)
                .HasColumnType("NVARCHAR(500)").IsRequired(false);


            modelBuilder
                .HasOne(prd => prd.Category)
                .WithMany(cat => cat.Products)
                .HasForeignKey(prd => prd.CategoryId);

            modelBuilder
               .HasOne(prd => prd.Vendor)
               .WithMany(vendor => vendor.Products)
               .HasForeignKey(prd => prd.VendorId);

            //modelBuilder.HasQueryFilter(i => i.IsDelated == false && i.Quantity > 0);
           
        }
    }
}
