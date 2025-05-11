using EF_Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public OrderStatus Status { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public TypeOfPayment PaymentMethod { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual Client Client { get; set; }
        public string ClientId { get; set; }
        
        public virtual ICollection<OrderItem> Items { get; set; }

        public virtual Review Review { get; set; }
    }

    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.Property(c => c.TotalQuantity).IsRequired();
            modelBuilder.Property(c => c.Status)
                .HasDefaultValue(OrderStatus.Pending);

            modelBuilder
            .HasOne(ord => ord.Client)
            .WithMany(cl => cl.Orders)
            .HasForeignKey(ord => ord.ClientId);

        }
    }
}
