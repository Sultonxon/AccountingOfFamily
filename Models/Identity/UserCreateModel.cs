using System;
using Microsoft.AspNetCore.Http;

namespace AccountedOfFamily.Models.Identity
{
    public class UserCreateModel
    {
        public string Id { get; set; }
        public IFormFile Photo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasportSeriya { get; set; }
        public string PasportNumber { get; set; }
        public string Password { get; set; }
    }
}
