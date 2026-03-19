using Library.domain.Models;

namespace Library.Tests
{
    public class LoanTests
    {

        [Fact]
        public void CannotLoanBook_WhenAlreadyOnLoan()
        {
            var book = new Book { Id = 1, IsAvailable = false };

            var canLoan = book.IsAvailable;

            Assert.False(canLoan);
        }

    }
}