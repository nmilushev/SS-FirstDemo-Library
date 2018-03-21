using Demo_Library.Models.BookModels;
using System.Collections.Generic;

namespace Demo_Library.BussinessLogic
{
    public class LibraryManagement
    {
        private ICollection<Book> booksManipulatable;
        public IReadOnlyCollection<Book> Books => (IReadOnlyCollection<Book>)this.booksManipulatable;

        // TODO: adding, removing, filtering, sorting, searching
    }
}