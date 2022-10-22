using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.Repositories
{
    public interface IECategoryRepository
    {
        IEnumerable<ECategory> ECategories { get;  }
        ECategory Get(long Id);
        int Count();
        void Add(ECategory eCategory);
        void Update(ECategory eCategory);
        void Delete(long id);
    }
}
