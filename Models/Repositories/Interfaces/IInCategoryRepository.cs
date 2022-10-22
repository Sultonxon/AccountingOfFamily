using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public interface IInCategoryRepository
    {
        IEnumerable<InCategory> InCategories { get; }
        InCategory Get(long id);
        int Count();
        void Add(InCategory inCategory);
        void Update(InCategory inCategory);
        void Delete(long id);
    }
}
