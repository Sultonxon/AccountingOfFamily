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
    public class IncomeController : Controller
    {
        private IIncomeRepository incomeRepository;
        private IInCategoryRepository inCategoryRepository;
        private UserManager<AppUser> userManager;
        public IncomeController(IIncomeRepository incomeRepo, IInCategoryRepository catRepo, UserManager<AppUser> userMng)
        {
            incomeRepository = incomeRepo;
            inCategoryRepository = catRepo;
            userManager = userMng;
        }

        [HttpPost]
        public IActionResult Delete(long id, string returnUrl)
        {
            incomeRepository.Delete(id);
            return Redirect(returnUrl);
        }

        public IActionResult Edit(long id, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new IncomeEditModel
            {
                Income = incomeRepository.Get(id),
                Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName),
                Categories = inCategoryRepository.InCategories.ToList()
            });
        }

        [HttpPost]
        public IActionResult Update(Income income, string returnUrl, string NewCategoryName, string NewCategoryDescription)
        {
            if (income.InCategoryId==-1)
            {
                income.InCategoryId = 0;
                income.InCategory = new InCategory { Name = NewCategoryName, Description = NewCategoryDescription };
            }
            incomeRepository.Update(income);
            return Redirect(returnUrl);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new IncomeEditModel
            {
                Income = new Income(),
                Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName),
                Categories = inCategoryRepository.InCategories.ToList()
            });
        }
        
        [HttpPost]
        public IActionResult Create(Income income,string returnUrl, string NewCategoryName, string NewCategoryDescription)
        {
            income.Id = 0;
            income.DateSalary = DateTime.Now;
            if (income.InCategoryId == -1)
            {
                income.InCategoryId = 0;
                income.InCategory = new InCategory { Name = NewCategoryName, Description = NewCategoryDescription };
            }
            incomeRepository.Add(income);
            return Redirect(returnUrl);
        }
    }
}
