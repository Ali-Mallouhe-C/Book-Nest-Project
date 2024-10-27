using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class RatingConfigurations : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(b => new {b.UserId, b.BookId}).IsUnique();

            builder.HasOne(b => b.User)
                        .WithMany()
                        .IsRequired(false)
                        .HasForeignKey(b => b.UserId);

            builder.HasOne(r => r.Book)
                    .WithMany(b => b.Ratings)
                    .HasForeignKey(r => r.BookId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
