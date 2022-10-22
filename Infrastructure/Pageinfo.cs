using System.Collections.Generic;
using AccountedOfFamily.Models.Identity;
using System;
using System.Linq;

namespace AccountedOfFamily.Infrastructure
{
    public class Pageinfo
    {
        public int Length { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int CountPages => Length % PageSize == 0 ? Length / PageSize : Length / PageSize + 1;
    }

    public class PagedModel<T>
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public IList<DateTime> Months { get; set; }
        public IEnumerable<T> Elements { get; set; }
    }
}
