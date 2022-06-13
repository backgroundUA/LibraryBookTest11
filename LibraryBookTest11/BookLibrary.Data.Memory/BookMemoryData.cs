using LibraryBookTest11.BookLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookTest11.BookLibrary.Data.Memory
{
    public class BookMemoryData : IData<IBook>
    {
        private readonly List<IBook> _books;

        public BookMemoryData()
        {
            _books = new List<IBook>();
        }

        public void Add(IBook item)
        {
            _books.Add(item);
        }

        public void Delete(IBook item)
        {
            _books.Remove(item);
        }

        public IEnumerable<IBook> ReadAll()
        {
            return _books;
        }
    }
}
