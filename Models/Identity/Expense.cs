using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AccountedOfFamily.Models.Identity
{
    public class Expense
    {
        public long Id { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public DateTime DateExpense { get; set; }

        public long ECategoryId { get; set; }
        public ECategory ECategory { get; set; }

        public string Comment { get; set; }
    }
}
