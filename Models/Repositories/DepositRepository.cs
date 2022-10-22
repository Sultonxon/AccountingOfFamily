using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AccountedOfFamily.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountedOfFamily.Models.Repositories
{
    public class DepositRepository:IDepositRepository
    {
        private IdentityContext context;
        public DepositRepository(IdentityContext ctx) { context = ctx; }

        public IEnumerable<Deposit> Deposits => context.Deposits.Include(d => d.AppUser);

        public Deposit GetOne(long Id) => context.Deposits.Include(d=>d.AppUser).First(d=>d.Id==Id);

        public int Count() => context.Deposits.Count();

        public int Count(Expression< Func<Deposit, bool> >func) => context.Deposits.Count(func);

        public void Add(Deposit deposit)
        {
            context.Add(deposit);
            context.SaveChanges();
        }

        
        public void Delete(long Id)
        {
            context.Deposits.Remove(new Deposit { Id = Id });
            context.SaveChanges();
        }


        public void Update(Deposit deposit)
        {
            Deposit entity = context.Deposits.Find(deposit.Id);
            if (entity!=null)
            {
                entity.DateStart = deposit.DateStart;
                entity.Depositor = deposit.Depositor;
                entity.Amount = deposit.Amount;
                entity.AppUserId = deposit.AppUserId;
                entity.Deadline = deposit.Deadline;
                entity.NumberAccountDeposit = deposit.NumberAccountDeposit;
                context.SaveChanges();
            }
        }
    }
}
