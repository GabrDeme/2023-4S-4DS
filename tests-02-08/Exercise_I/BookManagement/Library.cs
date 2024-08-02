using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    public static class LibraryList
    {
        private static List<string> books = new List<string>();

        public static void AddBook(string book)
        {
            books.Add(book);
        }

        public static List<string> GetBooks()
        {
            return new List<string>(books);
        }
    }

}
