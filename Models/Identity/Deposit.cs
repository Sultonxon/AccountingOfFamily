using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountedOfFamily.Models.Identity
{
    public class Deposit
    {
        public long Id { get; set; }

        public string Depositor { get; set; }

        public decimal Amount { get; set; }

        public string NumberAccountDeposit { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int Deadline { get; set; }

        public DateTime DateStart { get; set; }
    }
}
