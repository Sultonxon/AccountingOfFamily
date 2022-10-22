using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System;

namespace AccountedOfFamily.Infrastructure
{
    public static class Extensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ?
                request.Path.ToString() + request.QueryString.ToString() 
                 : request.Path.ToString();

        public static DateTime IncrementMonth(this DateTime thisDate) => thisDate.Month == 12
            ? new DateTime(thisDate.Year + 1, 1, 1, thisDate.Hour, thisDate.Minute, thisDate.Second)
            : new DateTime(thisDate.Year, thisDate.Month + 1, 1, thisDate.Hour, thisDate.Minute, thisDate.Second);
    }
}
