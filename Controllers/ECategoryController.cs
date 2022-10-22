using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountedOfFamily.Models.Identity;
using AccountedOfFamily.Models.Repositories;
using AccountedOfFamily.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AccountedOfFamily.Controllers
{
    [Authorize]
    public class ECategoryController : Controller
    {
        private IECategoryRepository eCategoryRepository;
        public ECategoryController(IECategoryRepository repo)
        {
            eCategoryRepository = repo;
        }

        [HttpPost]
        public IActionResult Delete(long id, string returnUrl)
        {
            eCategoryRepository.Delete(id);
            return Redirect(returnUrl);
        }

        public IActionResult Edit(long id,string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new ECategoryEditModel { ECategory = eCategoryRepository.Get(id) });
        }

        [HttpPost]
        public IActionResult Update(ECategory category,string returnUrl)
        {
            eCategoryRepository.Update(category);
            return Redirect(returnUrl);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new ECategoryEditModel { ECategory = new ECategory() });
        }

        [HttpPost]
        public IActionResult Create(ECategory category, string returnUrl)
        {
            eCategoryRepository.Add(category);
            return Redirect(returnUrl);
        }
    }
}
