using Library.domain.Models;
using Library.mvc.Data;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Library.mvc.Controllers
{
        public class SeedController : Controller
        {
            private readonly ApplicationDbContext _context;

            public SeedController(ApplicationDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                if (_context.Books.Any())
                    return Content("Database already seeded!");

                var books = new List<Book>
    {
        new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Category = "Fantasy", Isbn = "111", IsAvailable = true },
        new Book { Title = "Harry Potter", Author = "J.K. Rowling", Category = "Fantasy", Isbn = "222", IsAvailable = true },
        new Book { Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Isbn = "333", IsAvailable = true },
        new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", Isbn = "444", IsAvailable = true },
        new Book { Title = "1984", Author = "George Orwell", Category = "Fiction", Isbn = "555", IsAvailable = true },
        new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Category = "Fiction", Isbn = "666", IsAvailable = true },
        new Book { Title = "The Alchemist", Author = "Paulo Coelho", Category = "Fiction", Isbn = "777", IsAvailable = true },
        new Book { Title = "Sapiens", Author = "Yuval Noah Harari", Category = "History", Isbn = "888", IsAvailable = true },
        new Book { Title = "Atomic Habits", Author = "James Clear", Category = "Self-Help", Isbn = "999", IsAvailable = true },
        new Book { Title = "Deep Work", Author = "Cal Newport", Category = "Productivity", Isbn = "101", IsAvailable = true }
    };

                _context.Books.AddRange(books);

                var members = new List<Member>
    {
        new Member { FullName = "John Smith", Email = "john@test.com", Phone = "111111111" },
        new Member { FullName = "Maria Silva", Email = "maria@test.com", Phone = "222222222" },
        new Member { FullName = "Ahmed Khan", Email = "ahmed@test.com", Phone = "333333333" },
        new Member { FullName = "Emily Johnson", Email = "emily@test.com", Phone = "444444444" },
        new Member { FullName = "Carlos Mendes", Email = "carlos@test.com", Phone = "555555555" }
    };

                _context.Members.AddRange(members);

                _context.SaveChanges();

                var dbBooks = _context.Books.ToList();
                var dbMembers = _context.Members.ToList();

                var loans = new List<Loan>
    {
        new Loan { BookId = dbBooks[0].Id, MemberId = dbMembers[0].Id, LoanDate = DateTime.Now.AddDays(-5), DueDate = DateTime.Now.AddDays(5), ReturnedDate = null },
        new Loan { BookId = dbBooks[1].Id, MemberId = dbMembers[1].Id, LoanDate = DateTime.Now.AddDays(-10), DueDate = DateTime.Now.AddDays(-2), ReturnedDate = null }, // overdue
        new Loan { BookId = dbBooks[2].Id, MemberId = dbMembers[2].Id, LoanDate = DateTime.Now.AddDays(-7), DueDate = DateTime.Now.AddDays(1), ReturnedDate = DateTime.Now.AddDays(-1) },
        new Loan { BookId = dbBooks[3].Id, MemberId = dbMembers[3].Id, LoanDate = DateTime.Now.AddDays(-3), DueDate = DateTime.Now.AddDays(7), ReturnedDate = null },
        new Loan { BookId = dbBooks[4].Id, MemberId = dbMembers[4].Id, LoanDate = DateTime.Now.AddDays(-15), DueDate = DateTime.Now.AddDays(-5), ReturnedDate = null } // overdue
    };

                _context.Loans.AddRange(loans);

                _context.SaveChanges();

                return Content("Personalised database seeded successfully!");

            
               
        }

    }
}

        
    
  