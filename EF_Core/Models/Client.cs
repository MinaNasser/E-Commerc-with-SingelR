using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class Client
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CartItem> CartList { get; set; }
        public virtual ICollection<FavoriteItem> FavoriteList { get; set; }
    }

    public class ClientConfigration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> modelBuilder)
        {
            modelBuilder.HasKey(i => i.UserId);
            modelBuilder
                .HasOne(v => v.User)
                .WithOne(u => u.Client)
                .HasForeignKey<Client>(v => v.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
