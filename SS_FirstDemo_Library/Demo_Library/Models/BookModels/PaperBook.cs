using System;

namespace Demo_Library.Models.BookModels
{
    public class PaperBook : Book
    {
        private const int MinPagesNumber = 1;

        private int numberOfPages;

        public PaperBook(string title, Author author, int yearPublished, int numberOfPages)
            : base(title, author, yearPublished, BookType.Paper)
        {
            this.NumberOfPages = numberOfPages;
        }

        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }
            set
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