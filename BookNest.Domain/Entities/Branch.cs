﻿namespace BookNest.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        //Navigation properties:
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }

}