using System;

namespace Demo_Library
{
    public static class OutputMessages
    {
        public static string InvalidName = "Invalid Author name, must be between {0} and {1} symbols";
        public static string InvalidTitle = "Invalid Title, must be between {0} and {1} symbols";
        public static string InvalidISBN = "Invalid ISBN, mist be exactly {0} digits";
        public static string InvalidAudioBookLength = "Invalid duration in minutes, must be more than {0}";
        public static string InvalidPaperBookLength = "Invalid number of pages, must be more than {0}";
        public static string InvalidTypeOfBook = "{0} is invalid type of book, possible types are {1} and {2}";
        public static string InvalidGenreOfBook = "{0} is invalid book genre, possible types are {1}, {2} and {3}";
        public static string FunctionNotImplemented = "Function not yet implemented!";
        public static string LibraryManagementHome = "****************************" + Environment.NewLine +
                                                     "**   Library Management   **" + Environment.NewLine +
                                                     "****************************" + Environment.NewLine +
                                                     "Would you like to" + Environment.NewLine +
                                                     "  sort" + Environment.NewLine +
                                                     "  search" + Environment.NewLine +
                                                     "  add" + Environment.NewLine +
                                                     "  remove" + Environment.NewLine +
                                                     "  print N" + Environment.NewLine +
                                                     "  print all" + Environment.NewLine +
                                                     "  end" + Environment.NewLine +
                                                     "****************************";
        public static string BookAdded = "Book \"{0}\" was added!";
        public static string InvalidBookInput = "Invalid input!";
        public static string ChooseAlgorithm = "Choose algorithm:" + Environment.NewLine +
            " 1. Bubble sort / year published" + Environment.NewLine +
            " 2. Bubble sort / author name" + Environment.NewLine +
            " 3. Bubble sort / ISBN" + Environment.NewLine +
            " 4. Merge sort / year published" + Environment.NewLine +
            " 5. Merge sort / ISBN";
        public static string BooksSorted = "Sorting done! Time elapsed: {0}m {1}s {2}ms";
        public static string SearchDone = "Searching done! Time elapsed: {0}m {1}s {2}ms";
        public static string ChooseOrder = "Ascending or Descending?";
        public static string InputISBN = "Input 13 digit ISBN";
        public static string BookRemoved = "Book removed!";
    }
}