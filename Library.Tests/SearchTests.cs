using Library.domain.Models;

namespace Library.Tests
{
    public class SearchTests
    {

        [Fact]
        public void SearchBooks_ReturnsMatchingTitle()
        {
            var books = new List<Book>
        {
            new Book { Title = "Harry Potter" },
            new Book { Title = "The Hobbit" }
        };

            var result = books.Where(b => b.Title.Contains("Harry")).ToList();

            Assert.Single(result);
        }
    }
}