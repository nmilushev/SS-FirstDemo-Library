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
    
        protected Book(long isbn, string bookType, string bookGenre, string title, Author author, int yearPublished)
        {
            this.ISBN = isbn;
            this.BookType = bookType;
            this.BookGenre = this.ValidateBookGenre(bookGenre);
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

        public string BookType { get; }

        public BookGenre BookGenre { get; }
       
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

        public Author Author { get; }

        public int YearPublished { get; }
     
        public BookGenre ValidateBookGenre(string bookGenre)
        {
            BookGenre objBookGenre;
            bool validGenre = Enum.TryParse(bookGenre, out objBookGenre);

            if (!validGenre)
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidGenreOfBook, bookGenre,
                    BookGenre.Drama.ToString(), BookGenre.Horror.ToString(), BookGenre.Romance.ToString()));
            }

            return objBookGenre;
        }

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