using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public interface IWaitingTransactionRepository
    {
        IEnumerable<WaitingTransaction> WaitingTransactions { get; }
        IEnumerable<WaitingTransaction> StartInInterval(DateTime from, DateTime to);
        IEnumerable<WaitingTransaction> EndInInterval(DateTime from, DateTime to);
        IEnumerable<WaitingTransaction> GetBy(Expression<Func<WaitingTransaction, bool>> func);
        WaitingTransaction Get(long Id);
        DateTime MaxDate { get; }
        DateTime MinDate { get; }
        IList<DateTime> Months { get; }
        int Count();
        int Count(Expression<Func<WaitingTransaction, bool>> func);
        void Add(WaitingTransaction waitingTransaction);
        void Update(WaitingTransaction waitingTransaction);
        void Delete(long Id);
    }
}
