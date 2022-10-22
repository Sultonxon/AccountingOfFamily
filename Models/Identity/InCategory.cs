using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountedOfFamily.Models.Identity
{
    public class InCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Income> Incomes { get; set; }
    }
}
