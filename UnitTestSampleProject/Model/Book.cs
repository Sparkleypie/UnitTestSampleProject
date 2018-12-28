using System;

namespace UnitTestSampleProject.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime YearOfPublication { get; set; }
        public string Genre { get; set; }
        public bool isComic { get; set; }
    }
}
