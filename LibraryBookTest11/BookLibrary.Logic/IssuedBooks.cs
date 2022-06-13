using LibraryBookTest11.BookLibrary.Interface;
using System;

namespace LibraryBookTest11.BookLibrary.Logic
{
    internal class IssuedBooks : IIssuedBook
    {
        public ILibrarian Librarian { get; set; }
        public IBook Book { get; set; }
        public IReader Reader { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return DateTime.ToString();
        }
    }
}
