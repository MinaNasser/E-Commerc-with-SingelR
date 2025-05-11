using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double SupPrice { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

    }
    public class CartItemConfigration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Quantity).HasDefaultValue(1);
            builder.Property(b => b.SupPrice).IsRequired();
            builder
               .HasOne(e => e.Product)
               .WithMany(e => e.CartList)
               .HasForeignKey(e => e.ProductID)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            builder
               .HasOne(e => e.Client)
               .WithMany(e => e.CartList)
               .HasForeignKey(e => e.ClientId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
        }
    }
}
