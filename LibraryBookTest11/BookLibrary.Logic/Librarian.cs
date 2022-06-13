using System;
using System.Collections;
using LibraryBookTest11.BookLibrary.Interface;

namespace LibraryBookTest11.BookLibrary.Logic
{
    public class Librarian : ILibrarian
    {
        public string Name { get ; set; }

        public Librarian(IData<IBook> bookData, IData<IIssuedBook> issuedData)
        {
            _bookData = bookData ??
                throw new ArgumentNullException(nameof(bookData));
            _issuedBookData = issuedData ??
                throw new ArgumentNullException(nameof(issuedData));
        }

        private readonly IData<IBook> _bookData;
        private readonly IData<IIssuedBook> _issuedBookData;
        public void Add(IBook book)
        {
            _bookData.Add(book);
        }

        public IEnumerable GetAllBook()
        {
            return _bookData.ReadAll();
        }

        public IIssuedBook GiveBook(IBook book)
        {
            _bookData.Delete(book);

            var issuedBook = new IssuedBooks
            {
                Book = book,
                Librarian = this,
                DateTime = DateTime.Now,

            };
            _issuedBookData.Add(issuedBook);
            return issuedBook;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
