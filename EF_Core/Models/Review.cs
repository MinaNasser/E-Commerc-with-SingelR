using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        
    }

    public class ReviewConfigration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> modelBuilder)
        {

            modelBuilder.HasKey(Review => Review.Id);
            modelBuilder.HasOne(Review => Review.Order)
            .WithOne(booking => booking.Review)
            .HasForeignKey<Review>(Review => Review.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
