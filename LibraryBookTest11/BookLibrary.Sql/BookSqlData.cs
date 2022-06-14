using LibraryBookTest11.BookLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookTest11.BookLibrary.Sql
{
    public class BookSqlData : IData<IBook>
    {
		public void Add(IBook item)
		{
			using (var db = new db())
			{
				var book = new BookEntity(item);
				db.Books.Add(book);
				db.SaveChanges();
			}
		}
		public IEnumerable<IBook> ReadAll()
		{
			using (var db = new db())
			{
				return db.Books.ToList();
			}
		}
		public void Delete(IBook item)
		{
			using (var db = new db())
			{
				var book = db.Books.SingleOrDefault(b => b.Author.Equals(item.Author) &&
					b.Title.Equals(item.Title) &&
					b.Year.Equals(item.Year));
				db.Books.Remove(book);
				db.SaveChanges();
			}
		}

	}
}
