using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
  //  [Authorize(Roles = "Admin")]
    public class LanguagesController : Controller
    {
        private readonly ITranslatorRepository<Languages> languagesRepository;

        public LanguagesController(ITranslatorRepository<Languages> languagesRepository)
        {
            this.languagesRepository = languagesRepository;
        }

        // GET: LanguagesController
        public ActionResult Index()
        {
            var languages = languagesRepository.List();
            return View(languages);
        }

        // GET: LanguagesController/Details/5
        public ActionResult Details(string id)
        {
            var language = languagesRepository.Find(id);
            return View(language);
        }

        // GET: LanguagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Languages language)
        {
            try
            {

                languagesRepository.Add(language);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LanguagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguagesController/Delete/5
        public ActionResult Delete(string id)
        {
            var language = languagesRepository.Find(id);

            return View(language);
        }

        // POST: LanguagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Languages language)
        {
            try
            {
                languagesRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
