using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;

namespace BookNest.Infrastructure.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>
    {
        public ReservationRepository(BookNestAppDbContext context) : base(context)
        {
        }
    }

}
