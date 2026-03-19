using Library.domain.Models;

namespace Library.Tests
{
    public class LogicTests
    {
        [Fact]
    public void Loan_IsOverdue_WhenDueDatePassed_AndNotReturned()
        {
            var loan = new Loan
            {
                DueDate = DateTime.Now.AddDays(-2),
                ReturnedDate = null
            };

            var isOverdue = loan.DueDate < DateTime.Now && loan.ReturnedDate == null;

            Assert.True(isOverdue);
        }
    }
}