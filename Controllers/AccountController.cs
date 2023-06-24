using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AccountedOfFamily.Models.Identity;
using Microsoft.AspNetCore.Hosting;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        SignInManager<AppUser> signInManager;
        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public AccountController(SignInManager<AppUser> signMng, UserManager<AppUser> userMng,
            RoleManager<IdentityRole> roleMng)
        {
            userManager = userMng;
            signInManager = signMng;
            roleManager = roleMng;
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            AppUser user = await userManager.FindByEmailAsync(model.Email);
            if (user==null)
            {
                ModelState.AddModelError("Email", "Invalid Eamil");
            }
            if (user!=null && user.UserName==model.Name)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                    .PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl??"/");
                }
            }
            ModelState.AddModelError("", "Invalid user or Password");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles() =>
            Ok(new { Roles = roleManager.Roles.Where(x => User.IsInRole(x.Name)) });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl); 
        }
    }
}
