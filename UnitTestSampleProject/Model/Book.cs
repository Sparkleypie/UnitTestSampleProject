using System;
using System.Collections.Generic;

namespace UnitTestSampleProject.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Genre { get; set; }
        public bool IsComic { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
