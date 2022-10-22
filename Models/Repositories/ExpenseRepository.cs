using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private IdentityContext context;
        public ExpenseRepository(IdentityContext ctx) { context = ctx; }

        public IEnumerable<Expense> Expenses => context.Expenses.Include(e => e.ECategory).Include(e=>e.AppUser);

        public IEnumerable<Expense> GetBy(Expression<Func<Expense, bool>> func) => context.Expenses.
            Include(e => e.ECategory).Include(e=>e.AppUser).Where(func);

        public IEnumerable<Expense> InInterval(DateTime from, DateTime to) =>
            context.Expenses.Include(e => e.ECategory).Include(e=>e.AppUser).Where(e => e.DateExpense >= from && e.DateExpense < to);

        public Expense Get(long Id) => context.Expenses.Include(e => e.ECategory).Include(e=>e.AppUser).First(e => e.Id == Id);


        public DateTime MaxDate => context.Expenses.Count() == 0 ? DateTime.Now 
                                    : context.Expenses.Max(w => w.DateExpense);

        public DateTime MinDate => context.Expenses.Count() == 0 ? DateTime.Now 
                                    : context.Expenses.Min(w => w.DateExpense);

        public IList<DateTime> Months => context.Expenses.Select(w => w.DateExpense)
            .Distinct().OrderByDescending(w => w).ToList()
            .Select(w => new DateTime(w.Year, w.Month, 1)).Distinct().ToList();

        public int Count(Expression<Func<Expense, bool>> func) => context.Expenses.Count(func);

        public int Count() => context.Expenses.Count();

        public void Add(Expense expense)
        {
            context.Expenses.Add(expense);
            context.SaveChanges();
        }

        public void Update(Expense expense)
        {
            Expense entity = context.Expenses.Find(expense.Id);
            if (entity != null) 
            {
                entity.Amount = expense.Amount;
                entity.DateExpense = expense.DateExpense;
                entity.ECategoryId = expense.ECategoryId;
                entity.AppUserId = expense.AppUserId;
            }
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.Expenses.Remove(new Expense { Id = id });
            context.SaveChanges();
        }
    }
}
