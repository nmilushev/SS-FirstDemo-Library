using Demo_Library.BussinessLogic;
using Demo_Library.Models.BookModels;
using System;

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
                try
                {
                    switch (input)
                    {
                        case "sort":
                            //add more functionality
                            Console.WriteLine(OutputMessages.ChooseAlgorithm);
                            int chooseAlgorithm = int.Parse(Console.ReadLine());
                            if (chooseAlgorithm == 1)
                            {
                                libraryManagement.SortYearAscBubble();
                            }
                            else if (chooseAlgorithm == 2)
                            {
                                libraryManagement.SortYearDescBubble();
                            }
                            else if (chooseAlgorithm == 3)
                            {
                                libraryManagement.SortAuthorNameAscBubble();
                            }
                            else if (chooseAlgorithm == 4)
                            {
                                libraryManagement.SortAuthorNameDescBubble();
                            }
                            break;
                        case "search":
                            //sort first, then search - what about more than 1 result?
                            //libraryManagement.SearchYearBinary(4);
                            break; 
                        case "add":
                        case "add book":
                            Console.WriteLine(OutputMessages.BookInputFormat);
                            input = Console.ReadLine();
                            libraryManagement.AddBook(input);
                            break;
                        case "remove":
                        case "remove book":
                            break;
                        case "print":
                        case "print books":
                            Console.WriteLine();
                            foreach (Book book in libraryManagement.Books)
                            {
                                Console.WriteLine(book);
                            }
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