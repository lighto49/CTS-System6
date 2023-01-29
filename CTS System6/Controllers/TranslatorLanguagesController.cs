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
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using CTS_System6.Data;

namespace CTS_System6.Controllers
{

    //[Authorize(Roles = "Translator, Customer")]
    public class TranslatorLanguagesController : Controller
    {
        private readonly ITranslatorRepository<TranslatorsLanguages> translatorRepository;
        private readonly ITranslatorRepository<Languages> languagesRepository;

        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;


        public TranslatorLanguagesController(ITranslatorRepository<TranslatorsLanguages> translatorRepository,
                                            ITranslatorRepository<Languages> languagesRepository,
                                            ApplicationDbContext db,
                                            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            this.translatorRepository = translatorRepository;
            this.languagesRepository = languagesRepository;
            this.db = db;
         //   _userManager = userManager;

        }

        // GET: TranslatorLanguagesController
        public ActionResult Index()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var trlanguages = translatorRepository.List(userid);
            var langs = languagesRepository.List();
            //ViewBag.Languages = new SelectList(langs);

            var TLInfo = (from a in trlanguages
                          join b in langs on a.FromLanguageId equals b.Id
                          join c in langs on a.ToLanguageId equals c.Id
                          select new TranslatorLanguageVM
                          {
                              Id = a.Id,
                              FromLanguageId = a.FromLanguageId,
                              ToLanguageId = a.ToLanguageId,
                              Status = a.Status,
                              FromName = b.Name,
                              ToName = c.Name
                          }).ToList();
            return View(TLInfo);
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
            var langs = languagesRepository.List();
     
            ViewBag.Lan = new SelectList(langs, "Id", "Name"); 
            return View();
        }

        // POST: TranslatorLanguagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TranslatorLanguageVM model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var exist = db.TranslatorsLanguages.Where(l => l.TranslatorId == userId && l.FromLanguageId == model.FromLanguageId && l.ToLanguageId == model.ToLanguageId).FirstOrDefault();
            var user = _userManager.Users.Where(u => u.Id == userId).FirstOrDefault();
            var needValidate = _userManager.IsInRoleAsync(user ,"Company").Result;


            try
            {
                if (model.ToLanguageId == model.FromLanguageId)
                {
                    ModelState.AddModelError(string.Empty, "Wrong Request!");
                    return View();
                }
                else if (exist is null)
                {
                    var language = new TranslatorsLanguages
                    {
                        FromLanguageId = model.FromLanguageId,
                        ToLanguageId = model.ToLanguageId,
                        Status = needValidate,
                        TranslatorId = userId
                    };
                    translatorRepository.Add(language);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Language Is Exists!");
                    return View();
                }      
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



        public ActionResult Delete(string id)
        {

            try
            {
                translatorRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
