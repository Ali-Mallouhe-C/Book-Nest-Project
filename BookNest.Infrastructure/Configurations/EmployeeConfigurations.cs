using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Salary)
           .HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Branch)
                    .WithMany(b => b.Employees)
                    .HasForeignKey(e => e.BranchId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
