using LibraryBookTest11.BookLibrary.Interface;
using LibraryBookTest11.BookLibrary.Logic;
using static LibraryBookTest11.View.Helpers;
using System;
using System.Linq;
using System.Text;
using LibraryBookTest11.BookLibrary.Data.Memory;
using LibraryBookTest11.LibraryBook.Settings;
using System.Collections.Generic;

namespace LibraryBookTest11
{
    partial class Program
    {
        private static Configuration _configuration;
        private static IBook CreateBook(string title, string author, string genre, int year)
        {
            var book = _configuration.Container.GetInstance<IBook>();
            book.Title = title;
            book.Author = author;
            book.Genre = genre;
            book.Year = year;

            var librarian = _configuration.Container.GetInstance<ILibrarian>();

            librarian.Add(book);

            return book;
        }

        private static IIssuedBook CreateIssuedBook(ILibrarian librarian, IBook book)
        {
            var library = _configuration.Container.GetInstance<ILibrarian>();
            var issuedBook = library.GiveBook(book);


            return issuedBook;
        }

        private static ILibrarian CreateLibrarian(string name)
        {
            var library = _configuration.Container.GetInstance<ILibrarian>();
            library.Name = name;

            return library;
        }

        private static IReader CreateReader(string name)
        {
            var reader = new Reader
            {
                Name = name,
            };
            return reader;
        }

        private static IEnumerable<IBook> GetAllBooks()
        {
            var librarian = _configuration.Container.GetInstance<ILibrarian>();
            var books = librarian.GetAllBook();

            return (IEnumerable<IBook>)books;
        }



        static void Main(string[] args)
        {

            try
            {
                _configuration = new Configuration();

                var librarian = CreateLibrarian("Зоя");

                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("Добрый день. Добро пожаловать в панель управления библиотекой");
        
                Console.WriteLine("Пожалуйста, введите нужную команду или help для помощи");
        
                Console.WriteLine();

                while (true)
                {
                    switch (ReadCommand())
                    {
                        case Command.Exit:
                            Environment.Exit(0);
                            break;
                        case Command.Help:
                            WriteHelpMessage();
                            break;
                        case Command.AddBook:
                            AddBook(librarian);
                            break;
                        case Command.GetAllBooks:
                            GetAllBooks(librarian);
                            break;
                        case Command.GiveBook:
                            GiveBook(librarian);
                            break;
                        default:
                            WriteErrorMessage("Не обрабатываемая команда");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void AddBook(ILibrarian librarian)
        {
            Console.WriteLine("Добавление новой книги");

            var author = ReadNotEmptyLine("Имя автора");
            var title = ReadNotEmptyLine("Название книги");
            var year = ReadIntLine("Год написания книги");
            var genre = ReadNotEmptyLine("Жанр книги");

            var book = CreateBook(title, author, genre, year)
                           ?? throw new Exception("Ошибка при добавлении книги");

            librarian.Add(book);
            Console.WriteLine("Книга успешно добавлена");
            Console.WriteLine();
        }
        private static void GetAllBooks(ILibrarian librarian)
        {
            Console.WriteLine("Список всех доступных в библиотеке книг:");

            var books = librarian.GetAllBook();
            foreach (var book in books)
            {
                Console.WriteLine($"\t{book}");
            }

            Console.WriteLine();
        }

        private static void GiveBook(ILibrarian librarian)
        {
            Console.WriteLine("Новая выдача книги");

            IBook book;
            while (true)
            {
                var name = ReadNotEmptyLine("Название книги");
                var nameReader = ReadNotEmptyLine("Введите имя читателя");
                var reader = CreateReader(nameReader);
                var books = librarian.GetAllBook();
                var result = books.OfType<Book>().FirstOrDefault(b => b.Title.Equals(name));

                if (result != null)
                {
                    book = result;
                    break;
                }

                WriteErrorMessage("Данная книга не найдена");
            }

            var issuedBook = CreateIssuedBook(librarian, book);
            Console.WriteLine($"Название книги: {issuedBook.Book.Title}");
            Console.WriteLine($"Год книги: {issuedBook.Book.Year}");
            Console.WriteLine($"Книгу выдал; {issuedBook.Librarian.Name}");
            Console.WriteLine($"{issuedBook.DateTime}");
            Console.WriteLine();

        }


    }    
}
