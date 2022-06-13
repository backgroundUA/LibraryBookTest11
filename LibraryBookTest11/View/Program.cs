using LibraryBookTest11.BookLibrary.Interface;
using LibraryBookTest11.BookLibrary.Logic;
using static LibraryBookTest11.View.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using LibraryBookTest11.BookLibrary.Data.Memory;

namespace LibraryBookTest11
{
    partial class Program
    {

        private static IBook CreateBook(string title, string author, string genre, int year)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = year
            };
            return book;
        }

        private static IIssuedBook CreateIssuedBook(ILibrarian librarian, IBook book, IReader reader)
        {
            var issuedBook = new IssuedBooks
            {
                Librarian = librarian,
                Book = book,
                Reader = reader,
                DateTime = DateTime.Now,

            };
            return issuedBook;
        }

        private static ILibrarian CreateLibrarian(string name)
        {
            var bookData = new BookMemoryData();
            var issuedData = new IssuedBookMemoryData();

            var librarian = new Librarian(bookData, issuedData)
            {
                Name = name,
            };
            return librarian;
        }

        private static IReader CreateReader(string name)
        {
            var reader = new Reader
            {
                Name = name,
            };
            return reader;
        }




        static void Main(string[] args)
        {

            try
            {
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
                            WriteErrorMessage("Не обрабатываемая команда. Свяжитесь с разработчиком");
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

            var issuedBook = CreateIssuedBook(librarian, book, CreateReader("Жора"));
            Console.WriteLine($"Название книги: {issuedBook.Book.Title}");
            Console.WriteLine($"Год книги: {issuedBook.Book.Year}");
            Console.WriteLine($"Книгу выдал; {issuedBook.Librarian.Name}");
            Console.WriteLine($"Читатель: {CreateReader("Жора")}");
            Console.WriteLine($"{issuedBook.DateTime}");
            Console.WriteLine();

        }


    }    
}
