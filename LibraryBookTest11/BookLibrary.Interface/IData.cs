using System;
using System.Collections.Generic;

namespace LibraryBookTest11.BookLibrary.Interface
{
    public interface IData<T>
    {
        IEnumerable<T> ReadAll();
        void Add(T item);
        void Delete(T item);
    }
}
