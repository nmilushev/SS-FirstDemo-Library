using Demo_Library.Models;
using Demo_Library.Models.BookModels;
using System;

namespace Demo_Library.Factrory
{
    public class BookFactory
    {
        public Book CreateBook(long isbn, string bookType, string bookGenre, string title, Author author, int yearPublished , int length)
        {
            BookGenre objBookGenre;
            bool validGenre = Enum.TryParse(bookGenre, out objBookGenre);

            if (!validGenre)
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidGenreOfBook, bookGenre,
                    BookGenre.Drama.ToString(), BookGenre.Horror.ToString(), BookGenre.Romance.ToString())); // adding new genre screws this one 
            }
    
            switch (bookType)
            {
                case "Audio":
                    return new AudioBook(isbn, objBookGenre, title, author, yearPublished, length);
                case "Paper":
                    return new PaperBook(isbn, objBookGenre, title, author, yearPublished, length);
                default:
                    throw new ArgumentException(string.Format(OutputMessages.InvalidTypeOfBook, bookType, "Audio", "Paper"));
            }
        }
    }
}