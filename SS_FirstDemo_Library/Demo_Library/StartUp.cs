using Demo_Library.BussinessLogic;
using Demo_Library.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Demo_Library
{
    class StartUp
    {
        static void Main()
        {
            //loads books from file, accessible trough libraryManagement.Books (readonly)
            LibraryManagement libraryManagement = new LibraryManagement();

            Console.WriteLine(OutputMessages.LibraryManagementHome);

            string input = String.Empty;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputArgs = input.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                try
                {
                    switch (command)
                    {
                        case "sort":
                            //add more functionality
                            Console.WriteLine(OutputMessages.ChooseAlgorithm);
                            int chooseAlgorithm = int.Parse(Console.ReadLine());
                            if (chooseAlgorithm == 1)
                                libraryManagement.SortYearAscBubble();
                            else if (chooseAlgorithm == 2)
                                libraryManagement.SortYearDescBubble();
                            else if (chooseAlgorithm == 3)
                                libraryManagement.SortAuthorNameAscBubble();
                            else if (chooseAlgorithm == 4)
                                libraryManagement.SortAuthorNameDescBubble();
                            else if (chooseAlgorithm == 5)
                                libraryManagement.SortISBNAscBubble();
                            else if (chooseAlgorithm == 6)
                                libraryManagement.SortISBNDescBubble();
                            else if (chooseAlgorithm == 7)
                            {
                                List<Book> books = libraryManagement.LoadBooks();
                                Stopwatch stopwatch = new Stopwatch();
                                stopwatch.Start();
                                libraryManagement.SortYearAscMerge(books);
                                stopwatch.Stop();

                                TimeSpan ts = stopwatch.Elapsed;
                                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            }
                            else if (chooseAlgorithm == 8)
                            {
                                List<Book> books = libraryManagement.LoadBooks();
                                Stopwatch stopwatch = new Stopwatch();
                                stopwatch.Start();
                                libraryManagement.SortYearDescMerge(books);
                                stopwatch.Stop();

                                TimeSpan ts = stopwatch.Elapsed;
                                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            }
                            else if (chooseAlgorithm == 9)
                            {
                                List<Book> books = libraryManagement.LoadBooks();
                                Stopwatch stopwatch = new Stopwatch();
                                stopwatch.Start();
                                libraryManagement.SortAscISBNMerge(books);
                                stopwatch.Stop();

                                TimeSpan ts = stopwatch.Elapsed;
                                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            }
                            else if (chooseAlgorithm == 10)
                            {
                                List<Book> books = libraryManagement.LoadBooks();
                                Stopwatch stopwatch = new Stopwatch();
                                stopwatch.Start();
                                libraryManagement.SortDescISBNMerge(books);
                                stopwatch.Stop();

                                TimeSpan ts = stopwatch.Elapsed;
                                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            }
                            break;
                        case "search":
                            long isbnToSearch = long.Parse(Console.ReadLine());
                            Book foundBook = libraryManagement.BinarySearchPerISBN(isbnToSearch);
                            Console.WriteLine((foundBook == null) ? "Book not found!" : foundBook.ToString());
                            break;
                        case "add":
                            Console.WriteLine(OutputMessages.BookInputFormat);
                            input = Console.ReadLine();
                            libraryManagement.AddBook(input);
                            break;
                        case "remove":
                            break;
                        case "print":
                            libraryManagement.PrintBooks(inputArgs[1]);
                            break;
                        default:
                            throw new NotImplementedException(OutputMessages.FunctionNotImplemented);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (NotImplementedException nie)
                {
                    Console.WriteLine(nie.Message);
                }
            }
        }
    }
}