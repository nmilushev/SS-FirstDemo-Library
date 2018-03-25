using Demo_Library.Models;
using System;

namespace Demo_Library.Factrory
{
    public class AuthorFactory
    {
        public Author CreateAuthor(string name, DateTime dateOfBirth)
        {
            return new Author(name, dateOfBirth);
        }
    }
}