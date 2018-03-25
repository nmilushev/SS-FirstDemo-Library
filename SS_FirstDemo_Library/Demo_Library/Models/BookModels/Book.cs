using System;

namespace Demo_Library.Models.BookModels
{
    public abstract class Book
    {
        private const int TitleMaxLength = 35;
        private const int TitleMinLength = 1;

        private string title;

        protected Book(string title, Author author, int yearPublished, string bookType, BookGenre bookGenre)
        {
            this.Title = title;
            this.Author = author;
            this.YearPublished = yearPublished;
            this.BookGenre = bookGenre;
            this.BookType = bookType;
        }

        public Author Author { get; private set; }
        public int YearPublished { get; private set; }
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > TitleMaxLength)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidTitle, TitleMinLength, TitleMaxLength));
                }
                title = value;
            }
        }
        public string BookType { get; private set; }
        public BookGenre BookGenre { get; private set; }

        public override string ToString()
        {
            return $"Title: {this.Title}\r\n" +
                $"Published: {this.YearPublished}\r\n" +
                $"Author: {this.Author.Name}, born: {this.Author.DateOfBirth:dd-mm-yyyy}\r\n" +
                $"----------------------------------------";
        }
    }
}