using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookManagement.Test
{
    public class LibraryUnitTest
    {
        [Fact]
        public void TestingAddBookMethod()
        {
            var book = "Cristianismo Puro e Simples";

            LibraryList.AddBook(book);
            var books = LibraryList.GetBooks();

            Assert.Contains(book, books);
        }

    }
}
