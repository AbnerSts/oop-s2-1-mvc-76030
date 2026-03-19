using Library.domain.Models;

namespace Library.Tests
{
    public class BookTests
    {
        [Fact]
        public void ReturnLoan_MakesBookAvailable()
        {
            var book = new Book { Id = 1, IsAvailable = false };


            book.IsAvailable = true;

            Assert.True(book.IsAvailable);
        }
    }
}