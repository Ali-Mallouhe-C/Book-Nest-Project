using BookNest.Domain.Entities;
using BookNest.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;


namespace BookNest.Infrastructure.DbContexts
{
    public class BookNestAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Book> Books { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Branch> Branches { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }
        
        public DbSet<Rating> Ratings { get; set; }
        
        public DbSet<Employee> Employees { get; set; }

        public BookNestAppDbContext(DbContextOptions<BookNestAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration(new RatingConfigurations());
            modelBuilder.ApplyConfiguration(new ReservationConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}