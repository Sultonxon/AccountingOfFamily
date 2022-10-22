using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AccountedOfFamily.Models.Identity
{
    public class IdentityContext:IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            
        }

        public DbSet<ECategory> ECategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<InCategory> InCategories { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public DbSet<WaitingTransaction> WaitingTransactions { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public static async Task Seed(IServiceProvider service)
        {
            IdentityContext context = service.GetRequiredService<IdentityContext>();
            if (context.Database.CanConnect())
            {

                context.Database.EnsureDeleted();

            }
            
            context.Database.Migrate();

            UserManager<AppUser> userManager = service.GetService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = service.GetService<RoleManager<IdentityRole>>();
            if ((await userManager.FindByNameAsync("Sultonxon")) == null)
            {
                await userManager.CreateAsync(new AppUser
                {
                    UserName = "Sultonxon",
                    FirstName = "Sultonxon",
                    LastName = "Qudratov",
                    Email = "qudratovsultonxon20011124@gmail.com",
                    PasportNumber = "8203212",
                    PasportSeriya = "AB",
                    BirthDay = new System.DateTime(2001, 11, 24),
                    PhoneNumber = "+998913182001"
                }, "20011124");
            }
            if ((await roleManager.FindByNameAsync("Admin")) == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if ((await roleManager.FindByNameAsync("User")) == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (!(await userManager.IsInRoleAsync(await userManager.FindByNameAsync("Sultonxon"),"Admin")))
            {
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync("Sultonxon"), "Admin");
            }
            if (!(await userManager.IsInRoleAsync(await userManager.FindByNameAsync("Sultonxon"), "User")))
            {
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync("Sultonxon"), "User");
            }

            
        }

    }
}
