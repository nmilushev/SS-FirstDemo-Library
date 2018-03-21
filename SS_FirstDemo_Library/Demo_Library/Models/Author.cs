using System;

namespace Demo_Library.Models
{
    public class Author
    {
        private const int NameMaxLength = 25;
        private const int NameMinLength = 3;

        private string name;

        public Author(string name, DateTime dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidName, NameMinLength, NameMaxLength));
                }
                name = value;
            }
        }
        public DateTime DateOfBirth { get; private set; }
    }
}