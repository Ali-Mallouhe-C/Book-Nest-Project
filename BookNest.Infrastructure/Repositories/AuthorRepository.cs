using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;

namespace BookNest.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository(BookNestAppDbContext context) : base(context)
        {
        }
    }

}
