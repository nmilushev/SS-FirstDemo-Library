using System;

namespace Demo_Library.Models.BookModels
{
    public class PaperBook : Book
    {
        private const int MinPagesNumber = 1;

        private int numberOfPages;

        public PaperBook(long isbn, string bookGenre, string title, Author author, int yearPublished, int numberOfPages) 
            : base(isbn, "Paper", bookGenre, title, author, yearPublished)
        {
            this.NumberOfPages = numberOfPages;
        }

        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }
            private set
            {
                if (value < MinPagesNumber)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidPaperBookLength, MinPagesNumber));
                }
                numberOfPages = value;
            }
        }
    }
}