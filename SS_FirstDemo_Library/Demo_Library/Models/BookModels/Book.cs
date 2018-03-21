using System;

namespace Demo_Library.Models.BookModels
{
    public abstract class Book //base class for both types of books
    {
        private const int TitleMaxLength = 30;
        private const int TitleMinLength = 1;

        private string title;

        protected Book(string title, Author author, int yearPublished, BookType bookType)
        {
            this.Title = title;
            this.Author = author;
            this.YearPublished = yearPublished;
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
        public BookType BookType { get; private set; }

        public override string ToString()
        {
            return $"Title: {this.Title}\r\n" +
                $"Published: {this.YearPublished}\r\n" +
                $"Author: {this.Author.Name}";
        }
    }
}