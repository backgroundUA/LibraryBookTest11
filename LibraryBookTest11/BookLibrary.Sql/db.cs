using System;
using System.Data.Entity;


namespace LibraryBookTest11
{
    internal class db : DbContext
    {
        public db() : base("BookLibrary")
        {
             
            
        }
    }
}
