using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    namespace Library.domain.Models
    {
        public class Member
        {
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            public string Phone { get; set; }

            public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        }
    }