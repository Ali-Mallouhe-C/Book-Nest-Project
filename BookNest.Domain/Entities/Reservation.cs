namespace BookNest.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        //Foreign Key: => one User With Many Reservation:
        public int UserId { get; set; }


        //Foreign Key: => one Book With Many Reservation:
        public int BookId { get; set; }


        //Foreign Key: => one Branch With Many Reservation:
        public int BranchId { get; set; }

        public DateTime CreatedDate { get; set; }


        //Navigation Properties: User -- Book -- Branch
        public User User { get; set; } = new User();
        public Book Book { get; set; } = new Book();
        public Branch Branch { get; set; } = new Branch();
    }
}
