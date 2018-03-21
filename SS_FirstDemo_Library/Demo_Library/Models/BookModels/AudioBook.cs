using System;

namespace Demo_Library.Models.BookModels
{
    public class AudioBook : Book
    {
        private const int MinDurationInMinutes = 10;

        private int durationInMinutes;

        public AudioBook(string title, Author author, int yearPublished, int durationInMinutes, BookGenre bookGenre) 
            : base(title, author, yearPublished, "Audio", bookGenre)
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