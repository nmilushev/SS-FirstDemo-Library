using System;

namespace Demo_Library.Models.BookModels
{
    public abstract class Book
    {
        private const int TitleMaxLength = 35;
        private const int TitleMinLength = 1;
        private const int ISBNexactLength = 13;

        private string title;
        private long isbn;

      
        protected Book(long isbn, string bookType, BookGenre bookGenre, string title, Author author, int yearPublished)
        {
            this.ISBN = isbn;
            this.BookType = bookType;
            this.BookGenre = bookGenre;
            this.Title = title;
            this.Author = author;
            this.YearPublished = yearPublished;
        }

        public long ISBN
        {
            get { return isbn; }
            private set
            {
                if (value.ToString().Length != ISBNexactLength)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidISBN, ISBNexactLength));
                }
                isbn = value;
            }
        }

        public string BookType { get; private set; }

        public BookGenre BookGenre { get; private set; }

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

        public Author Author { get; private set; }

        public int YearPublished { get; private set; }
     
        
        public override string ToString()
        {
            return $"ISBN: {this.ISBN}\r\n" +
                $"Title: {this.Title}\r\n" +
                $"Published: {this.YearPublished}\r\n" +
                $"Author: {this.Author.Name}, born: {this.Author.DateOfBirth:dd-mm-yyyy}\r\n" +
                $"----------------------------------------";
        }
    }
}