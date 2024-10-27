namespace BookNest.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public decimal Salary { get; set; }

        //Foreign Key: => relation between Employee and User (one to one) ---> required
        public int UserId { get; set; }

        //Foreign Key: => relation between Branch and Employee (one to many) ---> required
        public int BranchId { get; set; }

        //Navigation Properties:
        public Branch Branch { get; set; }
        public User User { get; set; }
    }

}