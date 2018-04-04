using Demo_Library.Models;
using Demo_Library.Models.BookModels;
using System;

namespace Demo_Library.Factrory
{
    public class BookFactory
    {
        public Book CreateBook(long isbn, string bookType, string bookGenre, string title, Author author, int yearPublished , int length)
        {
            
            switch (bookType)
            {
                case "Audio":
                    return new AudioBook(isbn, bookGenre, title, author, yearPublished, length);
                case "Paper":
                    return new PaperBook(isbn, bookGenre, title, author, yearPublished, length);
                default:
                    throw new ArgumentException(string.Format(OutputMessages.InvalidTypeOfBook, bookType, "Audio", "Paper"));
            }
        }
    }
}