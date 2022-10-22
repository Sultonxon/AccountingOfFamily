using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AccountedOfFamily.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountedOfFamily.Models.Repositories
{
    public class IncomeRepository:IIncomeRepository
    {
        private IdentityContext context;
        public IncomeRepository(IdentityContext ctx) { context = ctx; }

        public IEnumerable<Income> Incomes => context.Incomes.Include(i => i.InCategory).Include(i => i.AppUser);

        public IEnumerable<Income> GetBy(Expression<Func<Income, bool>> func) => context.Incomes
            .Include(i => i.InCategory).Include(i => i.AppUser).Where(func);

        public IEnumerable<Income> InInterval(DateTime from, DateTime to) => context.Incomes
            .Include(i => i.InCategory).Include(i => i.AppUser)
            .Where(i => i.DateSalary >= from && i.DateSalary <= to);

        public Income Get(long Id) => context.Incomes.Include(i => i.InCategory).Include(i => i.AppUser)
            .First(i => i.Id == Id);

        public DateTime MaxDate => context.Incomes.Count() == 0 ? DateTime.Now 
                                    : context.Incomes.Max(w => w.DateSalary);

        public DateTime MinDate => context.Incomes.Count() == 0 ? DateTime.Now 
                                    : context.Incomes.Min(w => w.DateSalary);

        public IList<DateTime> Months => context.Incomes.Select(i=>i.DateSalary)
            .Distinct().OrderByDescending(w => w).ToList()
            .Select(w => new DateTime(w.Year, w.Month, 1)).Distinct().ToList();
        public int Count() => context.Incomes.Count();

        public int Count(Expression<Func<Income, bool>> func) => context.Incomes.Count(func);

        public void Add(Income income)
        {
            context.Incomes.Add(income);
            context.SaveChanges();
        }

        public void Delete(long Id)
        {
            context.Incomes.Remove(new Income { Id = Id });
            context.SaveChanges();
        }

        public void Update(Income income)
        {
            Income entity = context.Incomes.Find(income.Id);
            if (entity!=null)
            {
                entity.AppUserId = income.AppUserId;
                entity.DateSalary = income.DateSalary;
                entity.Amount = income.Amount;
                entity.InCategoryId = income.InCategoryId;
            }
            context.SaveChanges();
        }
    }
}
