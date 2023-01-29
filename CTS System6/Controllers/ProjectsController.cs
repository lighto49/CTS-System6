using CTS_System6.ConstLists;
using CTS_System6.Data;
using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    //[Authorize(Roles = "Customer")]
    public class ProjectsController : Controller
    {
        private readonly ITranslatorRepository<Projects> projectRepository;
        private readonly ITranslatorRepository<Rate> rateRepository;

        ApplicationDbContext db;

        public ProjectsController(ITranslatorRepository<Projects> projectRepository, ApplicationDbContext _db, ITranslatorRepository<Rate> rateRepository)
        {
            db = _db;
            this.projectRepository = projectRepository;
            this.rateRepository = rateRepository;
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
            //List<Projects> projects = db.Projects.ToList();
            //List<Languages> languages = db.Languages.ToList();
            List<ApplicationUser> users = db.Users.ToList();
            List<Bids> bids = db.Bids.ToList();
            var rate = rateRepository.List();

            var countquery = from a in bids
                             where a.ProjectId == id
                             select a.TranslatorId;
            var count = countquery.Count();


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
                                 TranslatorLastName = b.LastName,
                                 TranslatorId = b.Id

                             }).ToList();
            var currentstatus = project1.Select(x => x.Status).FirstOrDefault();
            var translators = bidsinfo1.Select(x => new { Id = x.TranslatorId, Name = x.TranslatorFirstName + " " + x.TranslatorLastName });
            var selectedtranslator = project1.Select(x => x.SelectedTranslator).FirstOrDefault();
            var crate = 1;
            var drate = 1;
            var qrate = 1;
            var review = "";

            List<string> ls = new List<string>();

            if (currentstatus == "Available")
            {
                ls = new List<string> { currentstatus, "To Do", "On Hold"};
            }
            else if (currentstatus == "To Do")
            {
                ls = new List<string> { currentstatus, "Failed", "Completed"};   
            }
            else if (currentstatus == "On Hold")
            {
                ls = new List<string> { currentstatus, "Available" };
            }
            else
            {
                ls = new List<string> { currentstatus };
                //var rateInfo = db.Rate.Where(x => x.ProjectId == id && x.UserId == selectedtranslator).Select(x => new { x.CommunicationScale, x.DeliveryScale, x.QualityScale, x.Review }).SingleOrDefault();
                var rateInfo = (from r in rate
                                where r.ProjectId == id && r.UserId == selectedtranslator
                                select new CustomerProjectVM
                                {
                                    CommunicationScale = r.CommunicationScale,
                                    QualityScale = r.QualityScale,
                                    DeliveryScale = r.DeliveryScale,
                                    Review = r.Review
                                }).FirstOrDefault();

                crate = rateInfo.CommunicationScale;
                drate = rateInfo.DeliveryScale;
                qrate = rateInfo.QualityScale;
                review = rateInfo.Review;
            }

            //ls.Insert(0, currentstatus.ToString());

            ViewBag.StatusList = new SelectList(ls, selectedValue: currentstatus.ToString());
            //ViewBag.StatusList = ls;

            ViewBag.TranslatorList = new SelectList(translators, "Id", "Name", selectedtranslator);


            var model = new CustomerProjectVM {

                Id = id,
                pp = project1,
                cc = bidsinfo1,
                BidsCount = count.ToString(),
                CommunicationScale = crate,
                DeliveryScale = drate,
                QualityScale = qrate,
                Review = review,
                Status = currentstatus
            };
            
            return View(model);
        }

        // GET: ProjectsController1/Create
        public ActionResult Create()
        {
            var CustomerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.PS = "Available";
            ViewBag.CID = CustomerId;
            //ViewBag.StatusList = new SelectList(Currency.);
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

        [HttpPost]
        public ActionResult ChangeStatus(CustomerProjectVM CPVM)
        {
            int id = CPVM.Id;
            var currentstatus = db.Projects.Where(x => x.Id == id).Select(x => x.Status).FirstOrDefault();

            if (currentstatus != "Completed")
            {
                if (CPVM.Status == "Failed")
                {
                    projectRepository.UpdateElement(id.ToString(), "Status", "On Hold");
                }
                else
                {
                    projectRepository.UpdateElement(id.ToString(), "Status", CPVM.Status);
                }

                if (CPVM.Status == "To Do")
                {
                    projectRepository.UpdateElement(id.ToString(), "SelectedTranslator", CPVM.SelectedTranslator);
                }

                if (CPVM.Status == "Completed" || CPVM.Status == "Failed")
                {
                    //here i will add the rating insert commands

                    var rate = new Rate
                    {
                        UserId = CPVM.SelectedTranslator,
                        CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        ProjectId = CPVM.Id,
                        DeliveryScale = CPVM.DeliveryScale,
                        QualityScale = CPVM.QualityScale,
                        CommunicationScale = CPVM.CommunicationScale,
                        RateDate = DateTime.Now,
                        Review = CPVM.Review
                    };

                    rateRepository.Add(rate);
                }
            }

            return RedirectToAction("Details", new { id });
        }
    }
}
