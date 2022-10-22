using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AccountedOfFamily.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IUserValidator<AppUser> userValidator;
        private IWebHostEnvironment webhost;

        public AdminController(UserManager<AppUser> usermng, RoleManager<IdentityRole> rolemng
            ,IUserValidator<AppUser> validator, IWebHostEnvironment host)
        {
            userManager = usermng;
            roleManager = rolemng;
            userValidator = validator;
            webhost = host;
        }

        public IActionResult Users() => View(userManager.Users.Include(u => u.Expenses)
                                                              .Include(u => u.Incomes)
                                                              .Include(e => e.WaitingTransactions));

        public async Task<IActionResult> Delete(string id)
        {
            await userManager.DeleteAsync(await userManager.FindByIdAsync(id));
            return RedirectToAction(nameof(Users));
        }

        public IActionResult Create() => View(new UserCreateModel());

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel newUser)
        {
            string imgName = Guid.NewGuid().ToString();
            string imageFilePath=null;
            string filenamefordb = "";
            if (newUser.Photo == null)
            {
                imgName = null;
            }
            else
            {

                string rootfolder = Path.Combine("images");
                string folder = Path.Combine(webhost.WebRootPath, "images");
                imgName += "_" + newUser.Photo.FileName;
                imageFilePath = Path.Combine(folder, imgName);
                filenamefordb = Path.Combine(rootfolder, imgName);
                await newUser.Photo.CopyToAsync(new FileStream(imageFilePath,FileMode.Create));
            }
            AppUser user = new AppUser
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                UserName = newUser.UserName,
                Email = newUser.Email,
                PhoneNumber = newUser.PhoneNumber,
                BirthDay = newUser.BirthDay,
                PasportSeriya = newUser.PasportSeriya,
                PasportNumber = newUser.PasportNumber,
                Img=imgName is null?imgName : filenamefordb
            };
            IdentityResult result = await userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Введенний данних не подходить");
                return View(newUser);
            }

            user = await userManager.FindByEmailAsync(newUser.Email);
            await userManager.AddToRoleAsync(user, "User");
            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            return View(new UserCreateModel
            {
                Id=user.Id,
                FirstName=user.FirstName,
                LastName=user.LastName,
                UserName=user.UserName,
                Email=user.Email,
                PhoneNumber=user.PhoneNumber,
                PasportNumber=user.PasportNumber,
                PasportSeriya=user.PasportSeriya,
                BirthDay=user.BirthDay
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserCreateModel model,string id)
        {
            string imgName = Guid.NewGuid().ToString();
            string imageFilePath = null;
            string filenamefordb = "";
            if (model.Photo == null)
            {
                imgName = null;
            }
            else
            {
                string rootfolder=Path.Combine( "images");
                string folder = Path.Combine(webhost.WebRootPath, rootfolder);
                imgName += "_" + model.Photo.FileName;
                imageFilePath = Path.Combine(folder, imgName);
                filenamefordb= Path.Combine(rootfolder, imgName);
                await model.Photo.CopyToAsync(new FileStream(imageFilePath, FileMode.Create));
            }
            AppUser user = await userManager.FindByIdAsync(id);
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.PasportSeriya = model.PasportSeriya;
            user.PasportNumber = model.PasportNumber;
            user.BirthDay = model.BirthDay;
            user.Img = imgName is null ? imgName : filenamefordb;

            if (user!=null)
            {
                IdentityResult result = await userValidator.ValidateAsync(userManager, user);
                if (result.Succeeded)
                {
                    await userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Users));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return View(user);

        } 
    }
}
