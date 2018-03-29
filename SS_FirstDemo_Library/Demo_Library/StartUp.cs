using Demo_Library.BussinessLogic;
using System;


namespace Demo_Library
{
    class StartUp
    {
        static void Main()
        {
            LibraryManagement libraryManagement = new LibraryManagement();

            Console.WriteLine(OutputMessages.LibraryManagementHome);

            string input = String.Empty;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                try
                {
                    libraryManagement.ExecuteCommand(input);
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