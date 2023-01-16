using CTS_System6.Data;
using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    [Authorize(Roles = "Translator")]
    public class TranslatorProjectController : Controller
    {
        private readonly ITranslatorRepository<Rate> rateRepository;
        private readonly ITranslatorRepository<Projects> projectRepository;

        ApplicationDbContext db;

        public TranslatorProjectController(ApplicationDbContext _db, ITranslatorRepository<Rate> _rateRepository, ITranslatorRepository<Projects> _projectRepository)
        {
            db = _db;
            rateRepository = _rateRepository;
            projectRepository = _projectRepository;
            
        }

        public IActionResult Index()
        {
            List<Projects> projects = db.Projects.ToList();
            List<Languages> languages = db.Languages.ToList();
            List<ApplicationUser> users = db.Users.ToList();
            List<TranslatorsLanguages> userlanguages = db.TranslatorsLanguages.ToList();
            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var TranslatorProject = from a in projects
                                    join b in languages on a.FromLanguage equals b.Id
                                    join c in languages on a.ToLanguage equals c.Id
                                    join d in users on a.CustomerId equals d.Id
                                    join e in userlanguages on new { a.FromLanguage, a.ToLanguage } equals new { e.FromLanguage, e.ToLanguage }
                                    where  e.TranslatorId == userid
                                    select new TranslatorProjectVM
                                    {
                                        CustomerId = d.Id,
                                        Id = a.Id,
                                        Subject = a.Subject,
                                        Status = a.Status,
                                        Currency = a.Currency,
                                        Offer = a.Offer,
                                        DeliveryDate = a.DeliveryDate,
                                        PostDate = a.PostDate,
                                        FromLanguageName = b.Name,
                                        ToLanguageName = c.Name,
                                        CustomerFirstName = d.FirstName,
                                        CustomerLastName = d.LastName
                                    };
        
            return View(TranslatorProject);
        }

        public IActionResult Bid(int id)
        {
            List<Projects> projects = db.Projects.ToList();
            List<Languages> languages = db.Languages.ToList();
            List<ApplicationUser> users = db.Users.ToList();
            List<Bids> bids = db.Bids.ToList();

            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var bidstatus = db.Bids.Count(b => b.TranslatorId == userid);
            var countquery = from a in bids
                             where a.ProjectId == id
                             select a.TranslatorId;
            var count = countquery.Count();
            var bidinfo = db.Bids.Where(a => a.TranslatorId == userid && a.ProjectId == id).Select(a => new { a.Body, a.Currency, a.Offer }).SingleOrDefault();
            var TranslatorProject = new TranslatorProjectVM();
            var rateinfo = db.Rate.Where(r => r.ProjectId == id && r.CreatedBy == userid).SingleOrDefault();
            if (bidinfo == null) {
                TranslatorProject = (from a in projects
                                         join b in languages on a.FromLanguage equals b.Id
                                         join c in languages on a.ToLanguage equals c.Id
                                         join d in users on a.CustomerId equals d.Id
                                         where a.Id == id
                                         select new TranslatorProjectVM
                                         {
                                             Id = a.Id,
                                             CustomerId = a.CustomerId,
                                             Subject = a.Subject,
                                             Body = a.Body,
                                             Status = a.Status,
                                             Currency = a.Currency,
                                             Offer = a.Offer,
                                             DeliveryDate = a.DeliveryDate,
                                             PostDate = a.PostDate,
                                             FromLanguageName = b.Name,
                                             ToLanguageName = c.Name,
                                             CustomerFirstName = d.FirstName,
                                             CustomerLastName = d.LastName,
                                             BidsCount = count.ToString(),
                                             BidStatus = 0
                                         }).FirstOrDefault();
            }
            else
            {
                TranslatorProject = (from a in projects
                                         join b in languages on a.FromLanguage equals b.Id
                                         join c in languages on a.ToLanguage equals c.Id
                                         join d in users on a.CustomerId equals d.Id
                                         where a.Id == id
                                         select new TranslatorProjectVM
                                         {
                                             Id = a.Id,
                                             CustomerId = a.CustomerId,
                                             Subject = a.Subject,
                                             Body = a.Body,
                                             Status = a.Status,
                                             Currency = a.Currency,
                                             Offer = a.Offer,
                                             DeliveryDate = a.DeliveryDate,
                                             PostDate = a.PostDate,
                                             FromLanguageName = b.Name,
                                             ToLanguageName = c.Name,
                                             CustomerFirstName = d.FirstName,
                                             CustomerLastName = d.LastName,
                                             BidsCount = count.ToString(),
                                             BidStatus = 1,
                                             BBody = bidinfo.Body,
                                             BCurrency = bidinfo.Currency,
                                             BOffer = bidinfo.Offer,
                                             DeliveryScale = rateinfo.DeliveryScale,
                                             CommunicationScale = rateinfo.CommunicationScale,
                                             QualityScale = rateinfo.QualityScale,
                                             Review = rateinfo.Review
                                         }).FirstOrDefault();
            }
            
            return View(TranslatorProject);
        }

        [HttpPost]
        public IActionResult Bid(TranslatorProjectVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var bid = new Bids
            {
                ProjectId = model.Id,
                TranslatorId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Date = DateTime.Now,
                Body = model.BBody,
                Offer = model.BOffer,
                Currency = model.BCurrency
            };

            db.Bids.Add(bid);
            db.SaveChanges();

            return RedirectToAction(nameof(Bid));
        }

        [HttpPost]
        public ActionResult Rate(TranslatorProjectVM TPVM)
        {
            var id = TPVM.Id;
            var TranslatorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var projectAtt = db.Projects.Where(p => p.Id == id).Select(p => new { Status = p.Status, Translator = p.SelectedTranslator, Customer = p.CustomerId }).FirstOrDefault();

            if (projectAtt.Status == "Completed" && projectAtt.Translator == TranslatorId)
            {
                var rate = new Rate
                {
                    Review = TPVM.Review,
                    UserId = projectAtt.Customer,
                    RateDate = DateTime.Now,
                    CommunicationScale = TPVM.CommunicationScale,
                    DeliveryScale = TPVM.DeliveryScale,
                    QualityScale = TPVM.QualityScale,
                    CreatedBy = TranslatorId,
                    ProjectId = id
                };

                projectRepository.UpdateElement(id.ToString(), "Status", "Finally Closed");
                rateRepository.Add(rate);

            };

            return RedirectToAction("Bid", new { id });
        }

    }
}
