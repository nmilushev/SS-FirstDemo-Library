using Demo_Library.Factrory;
using Demo_Library.Models.BookModels;
using System.Collections.Generic;

namespace Demo_Library.BussinessLogic
{
    public class LibraryManagement
    {
        private AuthorFactory authorFactory;
        private BookFactory bookFactory;
        private ICollection<Book> booksManipulatable;

        public IReadOnlyCollection<Book> Books => (IReadOnlyCollection<Book>)this.booksManipulatable;

        // TODO: adding, removing, filtering, sorting, searching
    }
}