using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Controllers
{
    public class MigrationController : Controller
    {
        IServiceProvider serviceProvider;
        public MigrationController( IServiceProvider service)
        {
            serviceProvider = service;
        }
        public IActionResult Index(bool isMigrated=false)
        {
            return View(isMigrated);
        }

        public async Task<IActionResult> Migrate()
        {
            await IdentityContext.Seed(serviceProvider);
            return RedirectToAction(nameof(Index), new { isMigrated=true });
        }
    }
}
