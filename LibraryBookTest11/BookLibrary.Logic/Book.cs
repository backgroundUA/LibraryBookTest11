using LibraryBookTest11.BookLibrary.Interface;
using System;

namespace LibraryBookTest11.BookLibrary.Logic
{
    internal class Book : IBook

    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }



        public override string ToString()
        {
            return $"{Title} {Author} {Genre} {Year}";
        }
    }
}
