using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.Identity;
using AccountedOfFamily.Models.Repositories;
using AccountedOfFamily.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class WaitingTransactionController : Controller
    {
        public IWaitingTransactionRepository repository;
        public UserManager<AppUser> userManager;
        public WaitingTransactionController(IWaitingTransactionRepository repo, UserManager<AppUser> userMng)
        {
            repository = repo;
            userManager = userMng;
        }

        [HttpPost]
        public IActionResult Delete(long id, string returnUrl)
        {
            repository.Delete(id);
            return Redirect(returnUrl);
        }

        public IActionResult Edit(long id, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new WaitingTransactionEditModel
            {
                WaitingTransaction = repository.Get(id),
                Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName)
            });
        }

        [HttpPost]
        public IActionResult Update(WaitingTransaction transaction, string returnUrl)
        {
            repository.Update(transaction);
            return Redirect(returnUrl);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new WaitingTransactionEditModel
            {
                WaitingTransaction = new WaitingTransaction { EndDate=DateTime.Now },
                Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName)
            });
        }

        [HttpPost]
        public IActionResult Create(WaitingTransaction transaction, string returnUrl)
        {
            transaction.StartDate = DateTime.Now;
            repository.Add(transaction);
            return Redirect(returnUrl);
        }

    }
}
