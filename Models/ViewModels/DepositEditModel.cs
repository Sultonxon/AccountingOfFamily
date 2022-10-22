using AccountedOfFamily.Models.Identity;
using System.Collections.Generic;

namespace AccountedOfFamily.Models.ViewModels
{
    public class DepositEditModel
    {
        public Deposit Deposit { get; set; }

        public IDictionary<string,string> Users { get; set; }
    }
}
