using System;
using System.Collections.Generic;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.ViewModels
{
    public class ExpensesViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
