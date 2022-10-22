using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountedOfFamily.Models.Identity
{
    public class WaitingTransaction
    {
        public long Id { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Amount { get; set; }

        public bool isIncome { get; set; }
        
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string PartnerDescription { get; set; }

        public string Comment { get; set; }

    }
}
