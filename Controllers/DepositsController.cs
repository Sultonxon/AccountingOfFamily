using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AccountedOfFamily.Models.Identity;
using AccountedOfFamily.Models.Repositories;
using AccountedOfFamily.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class DepositsController : Controller
    {
        UserManager<AppUser> userManager;
        IDepositRepository depositRepository;
        public DepositsController(IDepositRepository depRepo,UserManager<AppUser> useMng)
        {
            depositRepository = depRepo;
            userManager = useMng;
        }
        [HttpPost]
        public IActionResult Delete(long id,string returnUrl)
        {
            depositRepository.Delete(id);
            return Redirect(returnUrl);
        }

        public IActionResult Edit(long id, string returnUrl)
        {
            Deposit deposit = depositRepository.GetOne(id);
            if (deposit == null) return Redirect(returnUrl);
            ViewBag.returnUrl = returnUrl;
            DepositEditModel editingDeposit = new DepositEditModel
            {
                Deposit = deposit
            };
            editingDeposit.Users = new Dictionary<string, string>();
            foreach (var user in userManager.Users)
            {
                editingDeposit.Users.Add(user.Id, user.FirstName);
            }
            return View(editingDeposit);
        }

        [HttpPost]
        public IActionResult Update(Deposit deposit,string returnUrl)
        {
            depositRepository.Update(deposit);
            return Redirect(returnUrl);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new DepositEditModel
                {
                    Deposit = new Deposit(),
                    Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName)
                });
        }

        [HttpPost]
        public IActionResult Create(Deposit deposit, string returnUrl)
        {
            deposit.Id = 0;
            deposit.DateStart = DateTime.Now;
            depositRepository.Add(deposit);
            return Redirect(returnUrl);
        }

    }
}
