using Demo_Library.Factrory;
using Demo_Library.Models.BookModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Demo_Library.Models;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Demo_Library.BussinessLogic
{
    public class LibraryManagement
    {
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
            long isbn = long.Parse(inputArgs[0].Trim());
            string bookType = inputArgs[1].Trim();
            string bookGenre = inputArgs[2].Trim();
            string title = inputArgs[3].Trim();
            string authorName = inputArgs[4].Trim();
            DateTime authorBday = DateTime.ParseExact(inputArgs[5].Trim(), "yyyy/mm/dd", CultureInfo.InvariantCulture);
            int yearPublished = int.Parse(inputArgs[6].Trim());
            int length = int.Parse(inputArgs[7].Trim());

            Author author = authorFactory.CreateAuthor(authorName, authorBday);
            Book book = bookFactory.CreateBook(isbn, bookType, bookGenre, title, author, yearPublished, length);

            return book;
        }

        //adding book to list, not manipulating the file
        private void AddBook()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(OutputMessages.InputISBN);
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Book type:");
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Book genre:");
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Title:");
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Author:");
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Author birthdate (yyyy/MM/dd):");
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Year published:");
            sb.Append(Console.ReadLine() + ",");
            Console.WriteLine("Length:");
            sb.Append(Console.ReadLine() + ",");

            Book bookToAdd = this.ParseBook(sb.ToString());
            this.booksManipulatable.Add(bookToAdd);
            Console.WriteLine(string.Format(OutputMessages.BookAdded, bookToAdd.Title));
        }

        private void RemoveBook(long isbn)
        {
            Book bookToRemove = this.booksManipulatable.SingleOrDefault(b => b.ISBN == isbn);

            if (bookToRemove == null)
            {
                throw new ArgumentException(OutputMessages.BookNotFound);
            }

            this.booksManipulatable.Remove(bookToRemove);
            Console.WriteLine(OutputMessages.BookRemoved);
        }

        //printing books
        private void PrintBooks(string secondArgument)
        {
            int result;
            bool validBooksToPrint = int.TryParse(secondArgument, out result);

            if (validBooksToPrint)
            {
                int booksPrintedCounter = 0;
                Console.WriteLine();
                foreach (Book book in this.Books.Take(result))
                {
                    Console.WriteLine(book);
                    booksPrintedCounter++;
                }
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
            }
        }

        private void ValidateISBN(string isbnToSearch)
        {
            Regex isbnPattern = new Regex(@"[0-9]{13}");
            if (!isbnPattern.IsMatch(isbnToSearch))
            {
                throw new ArgumentException(OutputMessages.InvalidBookInput);
            }
        }

        //Searching algorithm
        public IList<Book> ExecuteCommand(string input)
        {
            string[] inputArgs = input.Split(new char[] { ' ' },
                   StringSplitOptions.RemoveEmptyEntries);
            string command = string.Empty;
            if (inputArgs.Length > 0)
            {
                command = inputArgs[0];
            }
            switch (command)
            {
                case "sort":
                    Console.WriteLine(OutputMessages.ChooseAlgorithm);
                    int chooseAlgorithm = int.Parse(Console.ReadLine());
                    Console.WriteLine(OutputMessages.ChooseOrder);
                    string order = Console.ReadLine().ToLower();
                    if (chooseAlgorithm == 1)
                        this.booksManipulatable = (List<Book>)Algorithms.SortYearBubble(this.booksManipulatable, order);
                    else if (chooseAlgorithm == 2)
                        this.booksManipulatable = (List<Book>)Algorithms.SortAuthorNameBubble(this.booksManipulatable, order);
                    else if (chooseAlgorithm == 3)
                    {
                        stopwatch.Start();
                        this.booksManipulatable = (List<Book>)Algorithms.SortYearMerge(this.booksManipulatable, order);
                        stopwatch.Stop();
                        TimeSpan ts = stopwatch.Elapsed;
                        Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    }
                    else if (chooseAlgorithm == 4)
                    {
                        stopwatch.Start();
                        this.booksManipulatable = (List<Book>)Algorithms.SortAuthorMerge(this.booksManipulatable, order);
                        stopwatch.Stop();
                        TimeSpan ts = stopwatch.Elapsed;
                        Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    }
                    break;
                case "search":
                    this.booksManipulatable = (List<Book>)Algorithms.SortISBNMerge(this.booksManipulatable);
                    Console.WriteLine(OutputMessages.InputISBN);
                    string isbnStr = Console.ReadLine();
                    this.ValidateISBN(isbnStr);
                    long isbnToSearch = long.Parse(isbnStr);
                    Book foundBook = Algorithms.BinarySearchPerISBN(this.booksManipulatable, isbnToSearch);
                    Console.WriteLine(OutputMessages.SearchDone);
                    Console.WriteLine((foundBook == null) ? OutputMessages.BookNotFound : foundBook.ToString());
                    break;
                case "add":
                    this.AddBook();
                    break;
                case "remove":
                    Console.WriteLine(OutputMessages.InputISBN);
                    isbnStr = Console.ReadLine();
                    this.ValidateISBN(isbnStr);
                    isbnToSearch = long.Parse(isbnStr);
                    this.RemoveBook(isbnToSearch);
                    break;
                case "print":
                    string printArgument = String.Empty;
                    if (inputArgs.Length < 2)
                        printArgument = "all";
                    else
                        printArgument = inputArgs[1];
                    this.PrintBooks(printArgument);
                    break;
                default:
                    throw new NotImplementedException(OutputMessages.FunctionNotImplemented);
            }

            return this.booksManipulatable;
        }
    }
}