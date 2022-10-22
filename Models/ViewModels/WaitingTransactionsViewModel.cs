using System;
using System.Collections.Generic;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Models.ViewModels
{
    public class WaitingTransactionsViewModel
    {
        public IEnumerable<WaitingTransaction> WaitingTransactions { get; set; }
    }
}
