using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class ProductComment
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public class ProductCommentConfiguration : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UserName);
            builder.Property(c => c.Message).HasMaxLength(1000).IsRequired();
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.Product)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(c => c.ProductId);
        }
    }


}
