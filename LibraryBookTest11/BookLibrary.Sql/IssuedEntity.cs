using LibraryBookTest11.BookLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookTest11.BookLibrary.Sql
{
    internal class IssuedEntity : IIssuedBook
    {
		public int Id { get; set; }
		public string LibrarianName { get; set; }
		public string BookName { get; set; }
		public ILibrarian Librarian { get; set; }
		public IBook Book { get; set; }
		public DateTime DateTime { get; set; }

		public IReader Reader { get; set; }

		public IssuedEntity() { }

		public IssuedEntity(IIssuedBook item)
		{
			Reader = item.Reader;
			Id = 0;
			LibrarianName = item.Librarian.Name;
			Librarian = item.Librarian;
			Book = item.Book;
			BookName = item.Book.Title;
			DateTime = item.DateTime;

			
		}

		public override string ToString()
		{
			return DateTime.ToString();
		}
	}
}
