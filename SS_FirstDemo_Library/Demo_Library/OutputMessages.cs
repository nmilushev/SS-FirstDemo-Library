namespace Demo_Library
{
    public static class OutputMessages
    {
        public static string InvalidName = "Invalid Author name, must be between {0} and {1} symbols";
        public static string InvalidTitle = "Invalid Title, must be between {0} and {1} symbols";
        public static string InvalidAudioBookLength = "Invalid duration in minutes, must be more than {0}";
        public static string InvalidPaperBookLength = "Invalid number of pages, must be more than {0}";
        public static string InvalidTypeOfBook = "{0} is invalid type of book, possible types are {1} and {2}";
        public static string InvalidGenreOfBook = "{0} is invalid book genre, possible types are {1}, {2} and {3}";
        public static string FunctionNotImplemented = "Function not yet implemented!";
        public static string LibraryManagementHome = "****************************\r\n" +
                                                     "**   Library Management   **\r\n" +
                                                     "****************************\r\n"+
                                                     "Would you like to\r\n" +
                                                     "  sort\r\n" +
                                                     "  search\r\n" +
                                                     "  add book\r\n" +
                                                     "  remove book\r\n" +
                                                     "  print books\r\n" +
                                                     "  end\r\n" +
                                                     "****************************";
        public static string BookInputFormat = "Add book in format:\r\n" +
            "Type, Genre, Title, AuthorName, AuthorBirthdate (yyyy/mm/dd), YearPublished, Length";
        public static string BookAdded = "Book \"{0}\" was added!";
        public static string InvalidBookInput = "Invalid input!";
        public static string ChooseAlgorithm = "Choose algorithm:\r\n" +
            " 1. Bubble sort / year published ascending\r\n" +
            " 2. Bubble sort / year published descending\r\n" +
            " 3. Bubble sort / author name ascending\r\n" +
            " 4. Bubble sort / author name descending";
        //TO DO : add more functionality with rest sorting algorithms
        public static string BooksSorted = "Sorting done! Time elapsed: {0}m {1}s {2}ms";
        public static string SearchDone = "Searching done! Time elapsed: {0}m {1}s {2}ms";
    }
}