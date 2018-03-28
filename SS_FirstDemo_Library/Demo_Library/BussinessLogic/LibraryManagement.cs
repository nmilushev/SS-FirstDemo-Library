using Demo_Library.Factrory;
using Demo_Library.Models.BookModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Demo_Library.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Linq;

namespace Demo_Library.BussinessLogic
{
    public class LibraryManagement
    {
        // TODO: adding, removing, filtering, sorting, searching

        private AuthorFactory authorFactory;
        private BookFactory bookFactory;
        private List<Book> booksManipulatable;
        private Stopwatch stopwatch = new Stopwatch();

        public LibraryManagement()
        {
            this.authorFactory = new AuthorFactory();
            this.bookFactory = new BookFactory();
            this.booksManipulatable = LoadBooks();
        }

        public IReadOnlyCollection<Book> Books => (IReadOnlyCollection<Book>)this.booksManipulatable;

        //loading books from data.csv file
        public List<Book> LoadBooks()
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
            long isbn = long.Parse(inputArgs[0].Trim());
            string bookType = inputArgs[1].Trim();
            string bookGenre = inputArgs[2].Trim();
            string title = inputArgs[3].Trim();
            string authorName = inputArgs[4].Trim();
            DateTime authorBday = DateTime.ParseExact(inputArgs[5].Trim(), "yyyy/mm/dd", CultureInfo.InvariantCulture);
            short yearPublished = short.Parse(inputArgs[6].Trim());
            short length = short.Parse(inputArgs[7].Trim());

            Author author = authorFactory.CreateAuthor(authorName, authorBday);
            Book book = bookFactory.CreateBook(isbn, bookType, bookGenre, title, author, yearPublished, length);
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

        //printing books
        public void PrintBooks(string secondArgument)
        {
            bool validBooksToPrint = int.TryParse(secondArgument, out int result);

            if (validBooksToPrint)
            {
                int booksPrintedCounter = 0;
                Console.WriteLine();
                foreach (Book book in this.Books.Take(result))
                {
                    Console.WriteLine(book);
                    booksPrintedCounter++;
                }
                Console.WriteLine(booksPrintedCounter);
            }
            else
            {
                int booksPrintedCounter = 0;
                Console.WriteLine();
                foreach (Book book in this.Books)
                {
                    Console.WriteLine(book);
                    booksPrintedCounter++;
                }
                Console.WriteLine(booksPrintedCounter);
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

        public void SortISBNAscBubble()
        {
            stopwatch.Start();
            for (int p = this.booksManipulatable.Count - 1; p > 0; p--)
            {
                for (int i = 0; i <= p - 1; i++)
                {
                    if (this.booksManipulatable[i].ISBN > (this.booksManipulatable[i + 1].ISBN))
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
        public void SortISBNDescBubble()
        {
            stopwatch.Start();
            for (int p = this.booksManipulatable.Count - 1; p > 0; p--)
            {
                for (int i = 0; i <= p - 1; i++)
                {
                    if (this.booksManipulatable[i].ISBN < (this.booksManipulatable[i + 1].ISBN))
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

        //Merge sort
        public List<Book> SortYearAscMerge(List<Book> booksManipulatable)
        {
            if (booksManipulatable.Count <= 1)
            {
                return booksManipulatable;
            }

            List<Book> leftPart = new List<Book>();
            List<Book> rightPart = new List<Book>();

            int middle = booksManipulatable.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(booksManipulatable[i]);
            }
            for (int i = middle; i < booksManipulatable.Count; i++)
            {
                rightPart.Add(booksManipulatable[i]);
            }

            leftPart = SortYearAscMerge(leftPart);
            rightPart = SortYearAscMerge(rightPart);
            return SortYearAscMergeHelper(leftPart, rightPart);

        }
        private List<Book> SortYearAscMergeHelper(List<Book> leftPart, List<Book> rightPart)
        {
            List<Book> result = new List<Book>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (leftPart.First().YearPublished <= rightPart.First().YearPublished)
                    {
                        result.Add(leftPart.First());
                        leftPart.Remove(leftPart.First());
                    }
                    else
                    {
                        result.Add(rightPart.First());
                        rightPart.Remove(rightPart.First());
                    }
                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }
            this.booksManipulatable = result;
            return result;
        }
        public List<Book> SortYearDescMerge(List<Book> booksManipulatable)
        {
            if (booksManipulatable.Count <= 1)
            {
                return booksManipulatable;
            }

            List<Book> leftPart = new List<Book>();
            List<Book> rightPart = new List<Book>();

            int middle = booksManipulatable.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(booksManipulatable[i]);
            }
            for (int i = middle; i < booksManipulatable.Count; i++)
            {
                rightPart.Add(booksManipulatable[i]);
            }

            leftPart = SortYearDescMerge(leftPart);
            rightPart = SortYearDescMerge(rightPart);
            return SortYearDescMergeHelper(leftPart, rightPart);

        }
        private List<Book> SortYearDescMergeHelper(List<Book> leftPart, List<Book> rightPart)
        {
            List<Book> result = new List<Book>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (leftPart.First().YearPublished > rightPart.First().YearPublished)
                    {
                        result.Add(leftPart.First());
                        leftPart.Remove(leftPart.First());
                    }
                    else
                    {
                        result.Add(rightPart.First());
                        rightPart.Remove(rightPart.First());
                    }
                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }
            this.booksManipulatable = result;
            return result;
        }

        public List<Book> SortAscISBNMerge(List<Book> booksManipulatable)
        {
            if (booksManipulatable.Count <= 1)
            {
                return booksManipulatable;
            }

            List<Book> leftPart = new List<Book>();
            List<Book> rightPart = new List<Book>();

            int middle = booksManipulatable.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(booksManipulatable[i]);
            }
            for (int i = middle; i < booksManipulatable.Count; i++)
            {
                rightPart.Add(booksManipulatable[i]);
            }

            leftPart = SortAscISBNMerge(leftPart);
            rightPart = SortAscISBNMerge(rightPart);
            return SortAscISBNMergeHelper(leftPart, rightPart);

        }
        private List<Book> SortAscISBNMergeHelper(List<Book> leftPart, List<Book> rightPart)
        {
            List<Book> result = new List<Book>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (leftPart.First().ISBN <= rightPart.First().ISBN)
                    {
                        result.Add(leftPart.First());
                        leftPart.Remove(leftPart.First());
                    }
                    else
                    {
                        result.Add(rightPart.First());
                        rightPart.Remove(rightPart.First());
                    }
                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }
            this.booksManipulatable = result;
            return result;
        }
        public List<Book> SortDescISBNMerge(List<Book> booksManipulatable)
        {
            if (booksManipulatable.Count <= 1)
            {
                return booksManipulatable;
            }

            List<Book> leftPart = new List<Book>();
            List<Book> rightPart = new List<Book>();

            int middle = booksManipulatable.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(booksManipulatable[i]);
            }
            for (int i = middle; i < booksManipulatable.Count; i++)
            {
                rightPart.Add(booksManipulatable[i]);
            }

            leftPart = SortDescISBNMerge(leftPart);
            rightPart = SortDescISBNMerge(rightPart);
            return SortDescISBNMergeHelper(leftPart, rightPart);

        }
        private List<Book> SortDescISBNMergeHelper(List<Book> leftPart, List<Book> rightPart)
        {
            List<Book> result = new List<Book>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (leftPart.First().ISBN > rightPart.First().ISBN)
                    {
                        result.Add(leftPart.First());
                        leftPart.Remove(leftPart.First());
                    }
                    else
                    {
                        result.Add(rightPart.First());
                        rightPart.Remove(rightPart.First());
                    }
                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }
            this.booksManipulatable = result;
            return result;
        }

        //Searching algorithms
        public Book BinarySearchPerISBN(long isbnToSearch)
        {
            int left = 0;
            int right = this.booksManipulatable.Count - 1;
            stopwatch.Start();
            while (left < right)
            {
                int middle = (left + right) / 2;

                if (this.booksManipulatable[middle].ISBN > isbnToSearch)
                {
                    right = middle - 1;
                }
                else if (this.booksManipulatable[middle].ISBN < isbnToSearch)
                {
                    left = middle + 1;
                }
                else
                {
                    stopwatch.Stop();
                    TimeSpan timeSpanFound = stopwatch.Elapsed;
                    Console.WriteLine(OutputMessages.SearchDone, timeSpanFound.Minutes, timeSpanFound.Seconds, timeSpanFound.Milliseconds);

                    return booksManipulatable[middle];
                }
            }

            stopwatch.Stop();
            TimeSpan timeSpanNotFound = stopwatch.Elapsed;
            Console.WriteLine(OutputMessages.SearchDone, timeSpanNotFound.Minutes, timeSpanNotFound.Seconds, timeSpanNotFound.Milliseconds);

            return null;
        }
    }
}