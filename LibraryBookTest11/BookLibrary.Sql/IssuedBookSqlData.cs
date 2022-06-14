using LibraryBookTest11.BookLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookTest11.BookLibrary.Sql
{
	public class IssuedBookSqlData
	{
		public class CheckSqlData : IData<IIssuedBook>
		{
			public void Add(IIssuedBook item)
			{
				using (var db = new db())
				{
					var check = new IssuedEntity(item);
					db.Issued.Add(check);
					db.SaveChanges();
				}
			}

			public IEnumerable<IIssuedBook> ReadAll()
			{
				using (var db = new db())
				{
					return db.Issued.ToList();
				}
			}

			public void Delete(IIssuedBook item)
			{
				using (var db = new db())
				{
					var check = new IssuedEntity(item);
					db.Issued.Remove(check);
					db.SaveChanges();
				}
			}
		}
	}
}
