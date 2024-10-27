namespace BookNest.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Foreign Key: => relation between Role and User (one to many) ---> required
        public int RoleId { get; set; }

        //Navigation Properties:
        public Role Role { get; set; }
 
        public List<Reservation>? Reservations { get; set; }

    }

}