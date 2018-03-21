using Demo_Library.Models;
using Demo_Library.Models.BookModels;
using System;

namespace Demo_Library.Factrory
{
    public class BookFactory
    {
        public Book CreateBook(string bookType, string title, Author author, int yearPublished , int length)
        {
            switch (bookType)
            {
                case "Audio":
                    return new AudioBook(title, author, yearPublished, length);
                case "Paper":
                    return new PaperBook(title, author, yearPublished, length);
                default:
                    throw new ArgumentException(string.Format(OutputMessages.InvalidTypeOfBook, bookType, BookType.Audio.ToString(), BookType.Paper.ToString()));
            }
        }
    }
}