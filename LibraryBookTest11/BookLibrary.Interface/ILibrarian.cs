using System;
using System.Collections;

namespace LibraryBookTest11.BookLibrary.Interface

{
    public interface ILibrarian
    {
        string Name { get; set; }

        void Add(IBook book);
        IEnumerable GetAllBook();
        IIssuedBook GiveBook(IBook book);

    }
}
