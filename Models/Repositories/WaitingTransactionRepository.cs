using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public class WaitingTransactionRepository:IWaitingTransactionRepository
    {
        private IdentityContext context;
        public WaitingTransactionRepository(IdentityContext ctx) { context = ctx; }

        public IEnumerable<WaitingTransaction> WaitingTransactions => context.WaitingTransactions
            .Include(w => w.AppUser);

        public WaitingTransaction Get(long Id) => context.WaitingTransactions
            .Include(w => w.AppUser).First(w => w.Id == Id);

        public IEnumerable<WaitingTransaction> GetBy(Expression<Func<WaitingTransaction, bool>> func) => context.WaitingTransactions
            .Include(w => w.AppUser).Where(func);

        public IEnumerable<WaitingTransaction> StartInInterval(DateTime from, DateTime to) => context.WaitingTransactions
            .Include(w => w.AppUser).Where(w => w.StartDate >= from && w.StartDate <= to);

        public IEnumerable<WaitingTransaction> EndInInterval(DateTime from, DateTime to) => context.WaitingTransactions
            .Include(w => w.AppUser).Where(w => w.EndDate >= from && w.EndDate <= to);

        public DateTime MaxDate => context.WaitingTransactions.Count() == 0 ? DateTime.Now 
                                    : context.WaitingTransactions.Max(w => w.EndDate);

        public DateTime MinDate => context.WaitingTransactions.Count() == 0 ? DateTime.Now 
                                    : context.WaitingTransactions.Min(w => w.EndDate);

        public IList<DateTime> Months => context.WaitingTransactions.Select(w => w.EndDate)
            .Distinct().OrderByDescending(w => w).ToList()
            .Select(w => new DateTime(w.Year, w.Month, 1)).Distinct().ToList();
        public int Count() => context.WaitingTransactions
            .Include(w => w.AppUser).Count();

        public int Count(Expression<Func<WaitingTransaction, bool>> func) => context.WaitingTransactions
            .Include(w => w.AppUser).Where(func).Count();

        public void Add(WaitingTransaction waitingTransaction)
        {
            context.WaitingTransactions.Add(waitingTransaction);
            context.SaveChanges();
        }

        public void Delete(long Id)
        {
            context.WaitingTransactions.Remove(new WaitingTransaction { Id = Id });
            context.SaveChanges();
        }

        public void Update(WaitingTransaction waitingTransaction)
        {
            WaitingTransaction entity = context.WaitingTransactions.Find(waitingTransaction.Id);
            if (entity!=null)
            {
                entity.Amount = waitingTransaction.Amount;
                entity.AppUserId = waitingTransaction.AppUserId;
                entity.EndDate = waitingTransaction.EndDate;
                entity.PartnerDescription = waitingTransaction.PartnerDescription;
                entity.StartDate = waitingTransaction.StartDate;
            }
            context.SaveChanges();
        }
    }
}
