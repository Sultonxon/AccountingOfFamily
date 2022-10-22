using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public interface IDepositRepository
    {
        IEnumerable<Deposit> Deposits { get; }
        Deposit GetOne(long Id);
        int Count();
        int Count( Expression<Func<Deposit, bool>> func);
        void Add(Deposit deposit);
        void Update(Deposit deposit);
        void Delete(long Id);
    }
}
