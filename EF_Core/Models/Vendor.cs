using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class Vendor
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
    public class VendorConfigration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> modelBuilder)
        {
            modelBuilder.HasKey(i => i.UserId);

            modelBuilder
                .HasOne(v => v.User)
                .WithOne(u => u.Vendor)
                .HasForeignKey<Vendor>(v => v.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
