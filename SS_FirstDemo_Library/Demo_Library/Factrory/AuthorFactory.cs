using Demo_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Library.Factrory
{
    public class AuthorFactory
    {
        public Author CreateAuthor(string name, int year, int month, int day)
        {
            return new Author(name, new DateTime(year, month, day));
        }
    }
}
