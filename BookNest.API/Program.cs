
using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using BookNest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookNest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookNestAppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration["ConnectionStrings:MainConnection"])
            );

            builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
            builder.Services.AddScoped<IRepository<Branch>, BranchRepository>();
            builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();
            builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
            
            builder.Services.AddScoped<EmployeeRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<RatingRepository>();
            builder.Services.AddScoped<BookRepository>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
