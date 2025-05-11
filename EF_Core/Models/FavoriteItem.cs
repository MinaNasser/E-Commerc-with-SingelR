using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Models
{
    public class FavoriteItem
    {
        public int Id { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

    }
    public class FavoriteItemConfigration : IEntityTypeConfiguration<FavoriteItem>
    {
        public void Configure(EntityTypeBuilder<FavoriteItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder
               .HasOne(e => e.Product)
               .WithMany(e => e.FavoriteList)
               .HasForeignKey(e => e.ProductID)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            builder
               .HasOne(e => e.Client)
               .WithMany(e => e.FavoriteList)
               .HasForeignKey(e => e.ClientId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
        }
    }
}
