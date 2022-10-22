using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AccountedOfFamily.Models.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userMng)
        {
            userManager = userMng;
            
        }

        public IActionResult Index()
        {
            return View(userManager.Users.ToArray());
        }
    }
}
