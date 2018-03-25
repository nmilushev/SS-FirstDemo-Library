using Demo_Library.Factrory;
using Demo_Library.Models.BookModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Demo_Library.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Demo_Library.BussinessLogic
{
    public class LibraryManagement
    {
        // TODO: adding, removing, filtering, sorting, searching

        private AuthorFactory authorFactory;
        private BookFactory bookFactory;
        private IList<Book> booksManipulatable;
        private Stopwatch stopwatch = new Stopwatch();

        public LibraryManagement()
        {
            this.authorFactory = new AuthorFactory();
            this.bookFactory = new BookFactory();
            this.booksManipulatable = LoadBooks();
        }

        public IReadOnlyCollection<Book> Books => (IReadOnlyCollection<Book>)this.booksManipulatable;

        //loading books from data.csv file
        private List<Book> LoadBooks()
        {
            BookFactory bookFactory = new BookFactory();
            AuthorFactory authorFactory = new AuthorFactory();

            List<Book> books = new List<Book>();
            string[] dataLines = File.ReadAllLines("../../data.csv");

            foreach (var line in dataLines)
            {
                Book bookToAdd = ParseBook(line);

                books.Add(bookToAdd);
            }

            return books;
        }
        private Book ParseBook(string input)
        {
            string[] inputArgs = input.Split(new char[] { ',' });
            string bookType = inputArgs[0].Trim();
            string bookGenre = inputArgs[1].Trim();
            string title = inputArgs[2].Trim();
            string authorName = inputArgs[3].Trim();
            DateTime authorBday = DateTime.ParseExact(inputArgs[4].Trim(), "yyyy/mm/dd", CultureInfo.InvariantCulture);
            short yearPublished = short.Parse(inputArgs[5].Trim());
            short length = short.Parse(inputArgs[6].Trim());

            Author author = authorFactory.CreateAuthor(authorName, authorBday);
            Book book = bookFactory.CreateBook(bookType, bookGenre, title, author, yearPublished, length);
            return book;
        }

        //adding book to list, not manipulating the file
        public void AddBook(string input)
        {
            //pattern allows digits in author name
            Regex pattern =
                new Regex(@"^[\w]+[,]+[\s]*.+[,]+[\s]*.+[,]+[\s]*.+[,]+[\s]*[0-9]{4}[\/]+[0-9]{2}[\/]+[0-9]{2}[,]+[\s]*[0-9]{4}[,][\s]*[0-9]+$");
            if (pattern.Match(input).Success)
            {
                Book bookToAdd = ParseBook(input);
                this.booksManipulatable.Add(bookToAdd);
                Console.WriteLine(string.Format(OutputMessages.BookAdded, bookToAdd.Title));
            }
            else
            {
                Console.WriteLine(OutputMessages.InvalidBookInput);
            }
        }

        //Sorting algorithms
            //Bubble sort
        public void SortYearAscBubble()
        {
            stopwatch.Start();
            for (int p = 0; p <= this.booksManipulatable.Count - 2; p++)
            {
                for (int i = 0; i <= this.booksManipulatable.Count - 2; i++)
                {
                    if (this.booksManipulatable[i].YearPublished > (this.booksManipulatable[i + 1].YearPublished))
                    {
                        Book temp = this.booksManipulatable[i + 1];
                        this.booksManipulatable[i + 1] = this.booksManipulatable[i];
                        this.booksManipulatable[i] = temp;
                    }
                }
            }
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        public void SortYearDescBubble()
        {
            stopwatch.Start();
            for (int p = 0; p <= this.booksManipulatable.Count - 2; p++)
            {
                for (int i = 0; i <= this.booksManipulatable.Count - 2; i++)
                {
                    if (this.booksManipulatable[i].YearPublished < (this.booksManipulatable[i + 1].YearPublished))
                    {
                        Book temp = this.booksManipulatable[i + 1];
                        this.booksManipulatable[i + 1] = this.booksManipulatable[i];
                        this.booksManipulatable[i] = temp;
                    }
                }
            }
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        public void SortAuthorNameAscBubble()
        {
            stopwatch.Start();
            for (int p = 0; p <= this.booksManipulatable.Count - 2; p++)
            {
                for (int i = 0; i <= this.booksManipulatable.Count - 2; i++)
                {
                    if (String.Compare(this.booksManipulatable[i].Author.Name, (this.booksManipulatable[i + 1].Author.Name)) == 1)
                    {
                        Book temp = this.booksManipulatable[i + 1];
                        this.booksManipulatable[i + 1] = this.booksManipulatable[i];
                        this.booksManipulatable[i] = temp;
                    }
                }
            }
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        public void SortAuthorNameDescBubble()
        {
            stopwatch.Start();
            for (int p = 0; p <= this.booksManipulatable.Count - 2; p++)
            {
                for (int i = 0; i <= this.booksManipulatable.Count - 2; i++)
                {
                    if (String.Compare(this.booksManipulatable[i].Author.Name, (this.booksManipulatable[i + 1].Author.Name)) == -1)
                    {
                        Book temp = this.booksManipulatable[i + 1];
                        this.booksManipulatable[i + 1] = this.booksManipulatable[i];
                        this.booksManipulatable[i] = temp;
                    }
                }
            }
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }


        //Searching algorithms
            //Binary search
    }
}