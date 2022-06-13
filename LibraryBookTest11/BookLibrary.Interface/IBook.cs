using System;

namespace LibraryBookTest11.BookLibrary.Interface
{
    public interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string Genre { get; set; }
        int Year { get; set; }

    }
}
