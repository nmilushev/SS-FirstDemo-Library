using System;

namespace Demo_Library.Models.BookModels
{
    public class AudioBook : Book
    {
        private const int MinDurationInMinutes = 10;

        private int durationInMinutes;

        public AudioBook(string title, Author author, int yearPublished, int durationInMinutes) 
            : base(title, author, yearPublished, BookType.Audio)
        {
            this.DurationInMinutes = durationInMinutes;
        }

        public int DurationInMinutes
        {
            get
            {
                return durationInMinutes;
            }
            set
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