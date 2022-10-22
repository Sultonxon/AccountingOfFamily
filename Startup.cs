using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using AccountedOfFamily.Models.Identity;
using Microsoft.EntityFrameworkCore;
using AccountedOfFamily.Models.Repositories;
using System;

namespace AccountedOfFamily
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:Identity"]);
            });
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnpoqrstuvxyz@#$%^&*() _";
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<IdentityContext>()
              .AddDefaultTokenProviders();
            
            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");
            services.AddTransient<IDepositRepository, DepositRepository>();
            services.AddTransient<IECategoryRepository, ECategoryRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IInCategoryRepository, InCategoryRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IWaitingTransactionRepository, WaitingTransactionRepository>();
            services.AddMvc(o => o.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                routes.MapRoute(name: "", template: "{controller}/{action}");
            });
            //IdentityContext.Seed(serviceProvider).Wait();
        }
    }
}
