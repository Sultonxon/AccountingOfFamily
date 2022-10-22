using System.Collections.Generic;
using System.Linq;
using AccountedOfFamily.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountedOfFamily.Models.Repositories
{
    public class ECategoryRepository:IECategoryRepository
    {
        private IdentityContext context;
        public ECategoryRepository(IdentityContext ctx) { context = ctx; }

        public IEnumerable<ECategory> ECategories => context.ECategories.Include(ec => ec.Expenses);

        public int Count() => context.ECategories.Count();

        public ECategory Get(long Id) => context.ECategories.
            Include(ec => ec.Expenses).First(ec => ec.Id == Id);

        public void Add(ECategory eCategory)
        {
            context.Add(eCategory);
            context.SaveChanges();
        }
        
        public void Update(ECategory eCategory)
        {
            ECategory entity = context.ECategories.Find(eCategory.Id);
            if (entity != null)
            {
                entity.Name = eCategory.Name;
                entity.Description = eCategory.Description;
                context.SaveChanges();
            }
        }
        public void Delete(long id)
        {
            context.ECategories.Remove(new ECategory { Id = id });
            context.SaveChanges();
        }

    }
}
