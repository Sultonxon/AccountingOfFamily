using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AccountedOfFamily.Models.Identity
{
    public class Income
    {
        public long Id { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [Required]
        public long InCategoryId { get; set; }
        public InCategory InCategory { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateSalary { get; set; }

        public string Comment { get; set; }
    }
}
