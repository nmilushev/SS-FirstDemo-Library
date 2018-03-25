using Demo_Library.Models;
using Demo_Library.Models.BookModels;
using System;

namespace Demo_Library.Factrory
{
    public class BookFactory
    {
        public Book CreateBook(string bookType, string bookGenre, string title, Author author, int yearPublished , int length)
        {

            bool validGenre = Enum.TryParse(bookGenre, out BookGenre objBookGenre);

            if (!validGenre)
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidGenreOfBook, bookGenre,
                    BookGenre.Drama.ToString(), BookGenre.Horror.ToString(), BookGenre.Romance.ToString())); // adding new genre screws this one 
            }
    
            switch (bookType)
            {
                case "Audio":
                    return new AudioBook(title, author, yearPublished, length, objBookGenre);
                case "Paper":
                    return new PaperBook(title, author, yearPublished, length, objBookGenre);
                default:
                    throw new ArgumentException(string.Format(OutputMessages.InvalidTypeOfBook, bookType, "Audio", "Paper"));
            }
        }
    }
}