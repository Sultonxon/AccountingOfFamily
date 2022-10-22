using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AccountedOfFamily.Models.Repositories;
using AccountedOfFamily.Models.ViewModels;
using AccountedOfFamily.Infrastructure;
using AccountedOfFamily.Models.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class EconomicController : Controller
    {
        private IDepositRepository depositRepository;
        private IECategoryRepository eCategoryRepository;
        private IExpenseRepository expenseRepository;
        private IInCategoryRepository inCategoryRepository;
        private IIncomeRepository incomeRepository;
        private IWaitingTransactionRepository waitingTransactionRepository;

        public EconomicController(IDepositRepository depRepo, IECategoryRepository eCatRepo,
            IExpenseRepository expenseRepo, IInCategoryRepository inCatRepo, IIncomeRepository incomeRepo,
            IWaitingTransactionRepository WaitRepo)
        {
            depositRepository = depRepo;
            eCategoryRepository = eCatRepo;
            expenseRepository = expenseRepo;
            inCategoryRepository = inCatRepo;
            incomeRepository = incomeRepo;
            waitingTransactionRepository = WaitRepo;
        }

        public IActionResult Deposits() =>
            View(new DepositsViewModel { Deposits = depositRepository.Deposits });


        public IActionResult ECategories() =>
            View(new ECategoriesViewModel { ECategories = eCategoryRepository.ECategories });


        public IActionResult Expenses(int year = 1, int month = 0)
        {
            if (year == 1)
            {
                year = expenseRepository.MaxDate.Year;
            }
            if (month==0)
            {
                month = expenseRepository.MaxDate.Month;
            }
            if (month > 12 || month < 1 || year < 1900 || year > 2100) return Forbid();
            var expenses = expenseRepository
                .InInterval(new DateTime(year, month, 1), new DateTime(year, month, LastDay(month, year),23,59,59));

            return View(new PagedModel<Expense>
            {
                Year = year,
                Month = month,
                MaxDate = expenseRepository.MaxDate,
                MinDate = expenseRepository.MinDate,
                Months = expenseRepository.Months,
                Elements = expenses
            });
        }

        public IActionResult InCategories() =>
            View(new InCategoriesViewModel { InCategories = inCategoryRepository.InCategories });


        public IActionResult Incomes(int year = 1, int month = 0)
        {
            if (year == 1)
            {
                year = expenseRepository.MaxDate.Year;
            }
            if (month == 0)
            {
                month = expenseRepository.MaxDate.Month;
            }
            if (month > 12 || month < 1 || year < 1900 || year > 2100) return Forbid();
            var incomes = incomeRepository
                .InInterval(new DateTime(year, month, 1), new DateTime(year, month, LastDay(month, year),23,59,59));
            return View(new PagedModel<Income>
            {
                Year = year,
                Month = month,
                MaxDate = incomeRepository.MaxDate,
                MinDate = incomeRepository.MinDate,
                Months = incomeRepository.Months,
                Elements = incomes
            });
        }
        public IActionResult WaitingTransactions(int year = 1, int month = 0)
        {
            if (year == 1)
            {
                year = expenseRepository.MaxDate.Year;
            }
            if (month == 0)
            {
                month = expenseRepository.MaxDate.Month;
            }
            if (month > 12 || month < 1 || year < 1900 || year > 2100) return Forbid();
            var incomes = waitingTransactionRepository
                .EndInInterval(new DateTime(year, month, 1), new DateTime(year, month, LastDay(month, year),23,59,59));

            return View(new PagedModel<WaitingTransaction>
            {
                Year = year,
                Month = month,
                MaxDate = waitingTransactionRepository.MaxDate,
                MinDate = waitingTransactionRepository.MinDate,
                Months = waitingTransactionRepository.Months,
                Elements = incomes.OrderByDescending(e => e.EndDate)
            });
        }

        public static int LastDay(int month, int year)
        {
            switch (month)
            {
                case 1: return 31;
                case 2: if (year % 4 == 0) return 29; else return 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: return 31;


            }
        }
    }
}
