using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class RatingRepository
    {
        private readonly BookNestAppDbContext _context;

        public RatingRepository(BookNestAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(int userId, int bookId, int star, string feedback)
        {
            //if the star number is not between 5 and 1
            if (star > 5 || star < 1)
                throw new ArgumentException("Star must be between 1 and 5.");

            //check if it was an existing rating by this user(userId) for this book(bookId)
            var existingRating = await _context.Ratings
                                        .FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId);

            //if true updating the existing rating
            if (existingRating != null)
            {
                existingRating.Star = star;
                existingRating.FeedBack = feedback;
            }

            //if not create new rating:
            else
            {
                var rate = new Rating
                {
                    Star = star,
                    UserId = userId,
                    BookId = bookId,
                    FeedBack = feedback
                };
                await _context.Ratings.AddAsync(rate);
            }

            //save changes:
            await _context.SaveChangesAsync();
        }
    }

}
