using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CTS_System6.Controllers
{

    [Authorize(Roles = "Translator, Customer")]
    public class TranslatorLanguagesController : Controller
    {
        private readonly ITranslatorRepository<TranslatorsLanguages> translatorRepository;
       // private readonly UserManager<ApplicationUser> _userManager;


        public TranslatorLanguagesController(ITranslatorRepository<TranslatorsLanguages> translatorRepository)
        {
            this.translatorRepository = translatorRepository;
         //   _userManager = userManager;

        }

        // GET: TranslatorLanguagesController
        public ActionResult Index()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var languages = translatorRepository.List(userid);
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
            var translatorid = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewBag.TID = translatorid;
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
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
            return RedirectToAction(nameof(Index));
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
