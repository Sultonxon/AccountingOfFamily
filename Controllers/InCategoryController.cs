using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.ViewModels;
using AccountedOfFamily.Models.Repositories;
using AccountedOfFamily.Models.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class InCategoryController : Controller
    {
        private IInCategoryRepository inCategoryRepository;
        public InCategoryController(IInCategoryRepository repo)
        {
            inCategoryRepository = repo;
        }

        [HttpPost]
        public IActionResult Delete(long id, string returnUrl)
        {
            inCategoryRepository.Delete(id);
            return Redirect(returnUrl);
        }
        
        public IActionResult Edit(long id, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new InCategoryEditModel
            {
                InCategory = inCategoryRepository.Get(id)
            });
        }

        [HttpPost]
        public IActionResult Update(InCategory inCategory, string returnUrl)
        {
            inCategoryRepository.Update(inCategory);
            return Redirect(returnUrl);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new InCategoryEditModel { InCategory = new InCategory() });
        }

        [HttpPost]
        public IActionResult Create(InCategory inCategory, string returnUrl)
        {
            inCategory.Id = 0;
            inCategoryRepository.Add(inCategory);
            return Redirect(returnUrl);
        }
    }
}
