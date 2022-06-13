using System;


namespace LibraryBookTest11.BookLibrary.Interface
{
    public interface IIssuedBook
    {
        ILibrarian Librarian { get; set; }
        IBook Book { get; set; }
        IReader Reader { get; set; }
        DateTime DateTime { get; set; }

    }
}
