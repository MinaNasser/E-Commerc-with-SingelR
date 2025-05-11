using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class ProductAttachment
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductAttachmentConfigration : IEntityTypeConfiguration<ProductAttachment>
    {
        public void Configure(EntityTypeBuilder<ProductAttachment> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);

            modelBuilder
                .HasOne(c => c.Product)
                .WithMany(c => c.Attachments)
                .HasForeignKey(c => c.ProductId);

        }
    }
}
