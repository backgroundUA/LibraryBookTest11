using LibraryBookTest11.BookLibrary.Sql;
using System;
using System.Data.Entity;


namespace LibraryBookTest11
{
    internal class db : DbContext
    {
        internal db() : base("BookLibrary") { }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<IssuedEntity> Issued { get; set; }

    }
    
}
