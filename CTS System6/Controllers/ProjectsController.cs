using CTS_System6.Data;
using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ITranslatorRepository<Projects> projectRepository;

        ApplicationDbContext db;

        public ProjectsController(ITranslatorRepository<Projects> projectRepository, ApplicationDbContext _db)
        {
            db = _db;
            this.projectRepository = projectRepository;
        }


        // GET: ProjectsController1
        public ActionResult Index()
        {
            var projects = projectRepository.List();
            return View(projects);
        }

        // GET: ProjectsController1/Details/5
        public ActionResult Details(int id)
        {
            List<Projects> projects = db.Projects.ToList();
            List<Languages> languages = db.Languages.ToList();
            List<ApplicationUser> users = db.Users.ToList();
            List<Bids> bids = db.Bids.ToList();
            var countquery = from a in bids
                             where a.ProjectId == id
                             select a.TranslatorId;
            var count = countquery.Count();
            //var bidinfo = db.Bids.Select(a => new { a.Body, a.Currency, a.Offer });
            //var project = from a in projects
            //              join b in languages on a.FromLanguage equals b.Id
            //              join c in languages on a.ToLanguage equals c.Id
            //              join e in bids on a.Id equals e.ProjectId
            //              join d in users on e.TranslatorId equals d.Id
            //              where a.Id == id
            //              select new TranslatorProjectVM
            //              {
            //                  Id = a.Id,
            //                  Subject = a.Subject,
            //                  Body = a.Body,
            //                  Status = a.Status,
            //                  Currency = a.Currency,
            //                  Offer = a.Offer,
            //                  DeliveryDate = a.DeliveryDate,
            //                  PostDate = a.PostDate,
            //                  FromLanguageName = b.Name,
            //                  ToLanguageName = c.Name,
            //                  TranslatorFirstName = d.FirstName,
            //                  TranslatorLastName = d.LastName,
            //                  BidsCount = count.ToString(),
            //                  BBody = e.Body,
            //                  BCurrency = e.Currency,
            //                  BOffer = e.Offer,
            //              };

            var project1 = db.Projects.Where(x => x.Id == id).ToList();
            var bids1 = db.Bids.Where(y => y.ProjectId == id).ToList();
            var bidsinfo1 = (from a in bids
                            join b in users on a.TranslatorId equals b.Id
                            where a.ProjectId == id
                            select new TranslatorProjectVM
                            {
                                BBody = a.Body,
                                BCurrency = a.Currency,
                                BOffer = a.Offer,
                                TranslatorFirstName = b.FirstName,
                                TranslatorLastName = b.LastName
                            }).ToList();

            var model = new CustomerProjectVM {

                pp = project1,
                //bb = bids1,
                cc = bidsinfo1
            };

            return View(model);
        }

        // GET: ProjectsController1/Create
        public ActionResult Create()
        {
            var CustomerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewBag.CID = CustomerId;
            return View();
        }

        // POST: ProjectsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projects project)
        {
            try
            {
                projectRepository.Add(project);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProjectsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectsController1/Edit/5
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

        // GET: ProjectsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
