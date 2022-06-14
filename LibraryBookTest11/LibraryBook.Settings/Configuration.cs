using LibraryBookTest11.BookLibrary.Data.Memory;
using LibraryBookTest11.BookLibrary.Interface;
using LibraryBookTest11.BookLibrary.Logic;
using LibraryBookTest11.BookLibrary.Sql;
using SimpleInjector;
using System;


namespace LibraryBookTest11.LibraryBook.Settings
{
    public class Configuration
    {
        public Container Container { get; }

        public Configuration()
        {
            Container = new Container();
            
                Setup();
            
        }
        public virtual void Setup()
        {
            Container.Register<IBook, Book>(Lifestyle.Transient);
            Container.Register<IIssuedBook, IssuedBooks>(Lifestyle.Transient);
            Container.Register<ILibrarian, Librarian>(Lifestyle.Singleton);
            Container.Register<IData<IBook>, BookMemoryData>(Lifestyle.Singleton);
            Container.Register<IData<IIssuedBook>, IssuedBookMemoryData>(Lifestyle.Singleton);
            
        }

    }
}
