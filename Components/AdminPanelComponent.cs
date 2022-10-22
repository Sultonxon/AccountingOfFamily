using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Identity;
using AccountedOfFamily.Models.Identity;

namespace AccountedOfFamily.Components
{
    public class AdminPanel : ViewComponent
    {
        public UserManager<AppUser> userManager;
        public  AdminPanel(UserManager<AppUser> userMng)
        {
            userManager = userMng;
        }
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                bool result = User.IsInRole("Admin");
                return View(result);
            }
            return View(false);
        }
    }
}
