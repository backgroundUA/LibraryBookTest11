using LibraryBookTest11.BookLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookTest11.BookLibrary.Data.Memory
{
    public class IssuedBookMemoryData : IData<IIssuedBook>
    {
        private readonly List<IIssuedBook> _issuedBook;

        public IssuedBookMemoryData()
        {
            _issuedBook = new List<IIssuedBook>();
        }
            
        
        public void Add(IIssuedBook item)
        {
            _issuedBook.Add(item);
        }

        public void Delete(IIssuedBook item)
        {
            _issuedBook.Remove(item);


        }

        public IEnumerable<IIssuedBook> ReadAll()
        {
            return _issuedBook;
        }
    }
}
