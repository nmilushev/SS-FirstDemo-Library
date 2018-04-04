using System;

namespace Demo_Library.Models.BookModels
{
    public class AudioBook : Book
    {
        private const int MinDurationInMinutes = 5;

        private int durationInMinutes;

        public AudioBook(long isbn, string bookGenre, string title, Author author, int yearPublished, int durationInMinutes)
            : base(isbn, "Audio", bookGenre, title, author, yearPublished)
        {
            this.DurationInMinutes = durationInMinutes;
        }

        public int DurationInMinutes
        {
            get
            {
                return durationInMinutes;
            }
            private set
            {
                if (value < MinDurationInMinutes)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidAudioBookLength, MinDurationInMinutes));
                }
                durationInMinutes = value;
            }
        }
    }
}