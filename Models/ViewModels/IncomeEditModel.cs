using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.ViewModels
{
    public class IncomeEditModel
    {
        public Income Income { get; set; }
        public IDictionary<string,string> Users { get; set; }
        public List<InCategory> Categories { get; set; }

        public string NewCategoryName { get; set; }
        public string NewCategoryDescription { get; set; }
    }
}
