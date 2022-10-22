using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> Incomes { get; }
        IEnumerable<Income> InInterval(DateTime from, DateTime to);
        IEnumerable<Income> GetBy(Expression<Func<Income, bool>> func);
        Income Get(long Id);
        DateTime MaxDate { get; }
        DateTime MinDate { get; }
        IList<DateTime> Months { get; }
        int Count();
        int Count(Expression<Func<Income, bool>> func);
        void Add(Income expense);
        void Update(Income expense);
        void Delete(long Id);
    }
}
