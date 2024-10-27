using System.ComponentModel.DataAnnotations;

namespace BookNest.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Star { get; set; }

        public string FeedBack { get; set; } = string.Empty;

        //Foreign Key: => one User With Many Ratings:
        public int UserId { get; set; }
        
        //Foreign Key: => one Book With Many Ratings:
        public int BookId { get; set; }

        //Navigation Properties:
        public User User { get; set; } = new User();
        public Book Book { get; set; } = new Book();


    }
}
