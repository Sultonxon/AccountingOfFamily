using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AccountedOfFamily.Models.Identity
{
    public class AppUser:IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasportSeriya { get; set; }
        public string PasportNumber { get; set; }
        public string Img { get; set; }

        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<WaitingTransaction> WaitingTransactions { get; set; }
    }
}
