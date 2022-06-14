using LibraryBookTest11.BookLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookTest11.BookLibrary.Sql
{
    internal class BookEntity : IBook
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }

		public string Genre { get; set; }

		public BookEntity() { }

		public BookEntity(IBook item)
		{
			Id = 0;
			Title = item.Title;
			Author = item.Author;
			Year = item.Year;
			Genre = item.Genre;
		}

		public override string ToString()
		{
			return $"{Author} {Title}";
		}
	}
}
