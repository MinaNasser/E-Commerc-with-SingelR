using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class OrderItem
    {
        public int Quantity { get; set; }


        public virtual Product Product { get; set; }
        public int ProductId { get; set; }


        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }

    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> modelBuilder)
        {
            modelBuilder.HasKey(c => new {c.OrderId, c.ProductId});
            modelBuilder.Property(o=>o.Quantity).HasDefaultValue(1);

            modelBuilder
                .HasOne(item => item.Order)
                .WithMany(Order => Order.Items)
                .HasForeignKey(item => item.OrderId);

            modelBuilder
                .HasOne(item => item.Product)
                .WithMany(Product => Product.OrderItems)
                .HasForeignKey(item => item.ProductId);
        }
    }
}

