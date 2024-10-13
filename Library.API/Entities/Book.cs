using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Writer { get; set; }
        public string? PublicationYear { get; set; }
        public int Price { get; set; }

    }
}