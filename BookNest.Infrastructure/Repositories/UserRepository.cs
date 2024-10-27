using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly BookNestAppDbContext _context;

        public UserRepository(BookNestAppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users
                            .Include(u => u.Role)
                            .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }
    }

}
