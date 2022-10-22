using System;
using System.Collections.Generic;
using System.Linq;
using AccountedOfFamily.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountedOfFamily.Models.Repositories
{
    public class InCategoryRepository : IInCategoryRepository
    {
        private IdentityContext context;
        public InCategoryRepository(IdentityContext ctx) { context = ctx; }

        public IEnumerable<InCategory> InCategories => context.InCategories
            .Include(c => c.Incomes);        

        public int Count() => context.InCategories.Count();        

        public InCategory Get(long id) => context.InCategories
            .Include(c => c.Incomes).First(c => c.Id == id);

        public void Add(InCategory inCategory)
        {
            context.InCategories.Add(inCategory);
            context.SaveChanges();
        }

        public void Update(InCategory inCategory)
        {
            InCategory entity = context.InCategories.Find(inCategory.Id);
            if (entity!=null)
            {
                entity.Name = inCategory.Name;
                entity.Description = inCategory.Description;
            }
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.InCategories.Remove(new InCategory { Id = id });
            context.SaveChanges();
        }
    }
}
