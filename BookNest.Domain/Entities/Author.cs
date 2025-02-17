﻿namespace BookNest.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? BIO { get; set; } = string.Empty;

        public DateTime? DOB { get; set; }

        //Navigation Properties: 
        public List<Book> Books { get; set; } = new List<Book>();
    }

}