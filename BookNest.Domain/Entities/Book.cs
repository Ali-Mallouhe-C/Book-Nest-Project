namespace BookNest.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ISBN { get; set; } = string.Empty;

        public DateTime PublishYear { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImgUrl { get; set; } = string.Empty;

        //Foreign Key: => relation between Category and Book (one to many) ---> required
        public int CategoryId { get; set; }

        //Foreign Key: => relation between Category and Book (one to many) ---> required
        public int AuthorId { get; set; }

        //Navigation Properties:
        public Category Category { get; set; } = new Category();
        public Author Author { get; set; } = new Author();

        public List<Rating>? Ratings { get; set; } = new List<Rating>();
        public List<Reservation>? Reservations { get; set; }
    }

}