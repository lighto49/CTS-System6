using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    public class TranslatorLanguagesController : Controller
    {
        private readonly ITranslatorRepository<TranslatorsLanguages> translatorRepository;

        public TranslatorLanguagesController(ITranslatorRepository<TranslatorsLanguages> translatorRepository)
        {
            this.translatorRepository = translatorRepository;
        }

        // GET: TranslatorLanguagesController
        public ActionResult Index()
        {
            var languages = translatorRepository.List();
            return View(languages);
        }

        // GET: TranslatorLanguagesController/Details/5
        public ActionResult Details(string id)
        {
            var user = translatorRepository.Find(id);

            return View(user);
        }

        // GET: TranslatorLanguagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TranslatorLanguagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TranslatorsLanguages language)
        {
            try
            {
                translatorRepository.Add(language);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TranslatorLanguagesController/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: TranslatorLanguagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
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

        // GET: TranslatorLanguagesController/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: TranslatorLanguagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
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
    }
}
