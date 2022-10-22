using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.ViewModels
{
    public class WaitingTransactionEditModel
    {
        public WaitingTransaction WaitingTransaction { get; set; }

        public IDictionary<string, string> Users { get; set; }
    }
}
