using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public static class Exercise
    {
        public class Book
        {
            public string? Titulo { get; set; }
        }
        public class LibraryList 
        { 
            private readonly List<Book> books = new List<Book>();

            public void AdicionarLivro(Book book)
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book));
                }
                books.Add(book);
            }
        }
    }

}
