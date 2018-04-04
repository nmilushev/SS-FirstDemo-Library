using Demo_Library.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Demo_Library.BussinessLogic
{
    public static class Algorithms
    {
        private static Stopwatch stopwatch = new Stopwatch();

        //Sorting algorithms
        //Bubble sort
        public static IList<Book> SortYearBubble(IList<Book> books, string order)
        {
            if (order == "ascending")
            {
                stopwatch.Start();
                for (int p = books.Count - 1; p > 0; p--)
                {
                    for (int i = 0; i <= p - 1; i++)
                    {
                        if (books[i].YearPublished > (books[i + 1].YearPublished))
                        {
                            Book temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                }

                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else
            {
                stopwatch.Start();
                for (int p = books.Count - 1; p > 0; p--)
                {
                    for (int i = 0; i <= p - 1; i++)
                    {
                        if (books[i].YearPublished < (books[i + 1].YearPublished))
                        {
                            Book temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                }

                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }

            return books;
        }

        public static IList<Book> SortAuthorNameBubble(IList<Book> books, string order)
        {
            if (order == "ascending")
            {
                stopwatch.Start();
                for (int p = books.Count - 1; p > 0; p--)
                {
                    for (int i = 0; i <= p - 1; i++)
                    {
                        if (String.Compare(books[i].Author.Name, (books[i + 1].Author.Name)) > 0)
                        {
                            Book temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                }
                stopwatch.Stop();

                TimeSpan ts = stopwatch.Elapsed;
                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else
            {
                stopwatch.Start();
                for (int p = books.Count - 1; p > 0; p--)
                {
                    for (int i = 0; i <= p - 1; i++)
                    {
                        if (String.Compare(books[i].Author.Name, (books[i + 1].Author.Name)) < 0)
                        {
                            Book temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                }
                stopwatch.Stop();

                TimeSpan ts = stopwatch.Elapsed;
                Console.WriteLine(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }

            return books;
        }

        //Merge sort
        public static IList<Book> SortYearMerge(IList<Book> books, string order)
        {
            if (books.Count <= 1)
            {
                return books;
            }

            IList<Book> leftPart = new List<Book>();
            IList<Book> rightPart = new List<Book>();

            int middle = books.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(books[i]);
            }
            for (int i = middle; i < books.Count; i++)
            {
                rightPart.Add(books[i]);
            }

            leftPart = SortYearMerge(leftPart, order);
            rightPart = SortYearMerge(rightPart, order);
            return SortYearMergeHelper(leftPart, rightPart, order);

        }
        private static IList<Book> SortYearMergeHelper(IList<Book> leftPart, IList<Book> rightPart, string order)
        {
            IList<Book> result = new List<Book>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (order == "ascending")
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
                    else
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
            return result;
        }

        public static IList<Book> SortAuthorMerge(IList<Book> books, string order)
        {
            if (books.Count <= 1)
            {
                return books;
            }

            IList<Book> leftPart = new List<Book>();
            IList<Book> rightPart = new List<Book>();

            int middle = books.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(books[i]);
            }
            for (int i = middle; i < books.Count; i++)
            {
                rightPart.Add(books[i]);
            }

            leftPart = SortAuthorMerge(leftPart, order);
            rightPart = SortAuthorMerge(rightPart, order);
            return SortAuthorMergeHelper(leftPart, rightPart, order);

        }
        private static IList<Book> SortAuthorMergeHelper(IList<Book> leftPart, IList<Book> rightPart, string order)
        {
            IList<Book> result = new List<Book>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (order == "ascending")
                    {
                        if (String.Compare(leftPart.First().Author.Name, rightPart.First().Author.Name) <= 0)
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
                    else
                    {
                        if (String.Compare(leftPart.First().Author.Name, rightPart.First().Author.Name) > 0)
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

            return result;
        }

        //Merge sort (ascending) on ISBN helping the binary searching
        public static IList<Book> SortISBNMerge(IList<Book> books)
        {
            if (books.Count <= 1)
            {
                return books;
            }

            IList<Book> leftPart = new List<Book>();
            IList<Book> rightPart = new List<Book>();

            int middle = books.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(books[i]);
            }
            for (int i = middle; i < books.Count; i++)
            {
                rightPart.Add(books[i]);
            }

            leftPart = SortISBNMerge(leftPart);
            rightPart = SortISBNMerge(rightPart);
            return SortISBNMergeHelper(leftPart, rightPart);

        } // remove
        private static IList<Book> SortISBNMergeHelper(IList<Book> leftPart, IList<Book> rightPart)
        {
            IList<Book> result = new List<Book>();

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

            return result;
        }

        //Binary search on ISBN
        public static Book BinarySearchPerISBN(IList<Book> books, long isbnToSearch)
        {
            int left = 0;
            int right = books.Count - 1;
            
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (books[middle].ISBN > isbnToSearch)
                {
                    right = middle - 1;
                }
                else if (books[middle].ISBN < isbnToSearch)
                {
                    left = middle + 1;
                }
                else
                {
                    return books[middle];
                }
            }

            return null;
        }
    }
}