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
    public class ExpenseController : Controller
    {
        private IExpenseRepository expenseRepository;
        private IECategoryRepository eCategoryRepository;
        private UserManager<AppUser> userManager;
        public ExpenseController(IExpenseRepository repo, IECategoryRepository erepo, UserManager<AppUser> userMng)
        {
            expenseRepository = repo;
            eCategoryRepository = erepo;
            userManager = userMng;
        }

        [HttpPost]
        public IActionResult Delete(long id, string returnUrl)
        {
            expenseRepository.Delete(id);
            return Redirect(returnUrl);
        }

        public IActionResult Edit(long id, string returnUrl)
        {
            Expense expense = expenseRepository.Get(id);
            ViewBag.returnUrl = returnUrl;
            return View(new ExpenseEditModel
            {
                Expense = expense,
                Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName),
                Categories = eCategoryRepository.ECategories.ToList()
            });
        }
        [HttpPost]
        public IActionResult Update(Expense expense,string returnUrl, string NewCategoryName, string NewCategoryDescription)
        {
            if (expense.ECategoryId==-1)
            {
                expense.ECategoryId = 0;
                expense.ECategory = new ECategory { Id = 0, Name = NewCategoryName, Description = NewCategoryDescription };
            }
            expenseRepository.Update(expense);
            return Redirect(returnUrl);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new ExpenseEditModel
            {
                Expense = new Expense(),
                Users = userManager.Users.ToDictionary(u => u.Id, u => u.FirstName),
                Categories=eCategoryRepository.ECategories.ToList()
            });
        }

        [HttpPost]
        public IActionResult Create(Expense expense,string returnUrl, string NewCategoryName, string NewCategoryDescription)
        {
            expense.Id = 0;
            expense.DateExpense = DateTime.Now;
            if (expense.ECategoryId == -1)
            {
                expense.ECategoryId = 0;
                expense.ECategory = new ECategory { Id = 0, Name = NewCategoryName, Description = NewCategoryDescription };
            }

            expenseRepository.Add(expense);
            return Redirect(returnUrl);
        }
    }
}
