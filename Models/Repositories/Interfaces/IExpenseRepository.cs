using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> Expenses { get;  }
        IEnumerable<Expense> InInterval(DateTime from, DateTime to);
        IEnumerable<Expense> GetBy(Expression<Func<Expense, bool>> func);
        Expense Get(long Id);
        DateTime MaxDate { get; }
        DateTime MinDate { get; }
        IList<DateTime> Months { get; }
        int Count();
        int Count(Expression<Func<Expense, bool>> func);
        void Add(Expense expense);
        void Update(Expense expense);
        void Delete(long Id);
    }
}
