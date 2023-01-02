using CTS_System6.Data;
using CTS_System6.Models;
using CTS_System6.Models.Repositories;
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    public class ViewUserProfileController : Controller
    {

        private readonly ITranslatorRepository<Rate> rateRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        ApplicationDbContext db;

        public ViewUserProfileController(ApplicationDbContext _db, ITranslatorRepository<Rate> rateRepository, UserManager<ApplicationUser> userManager)
        {
            db = _db;
            this.rateRepository = rateRepository;
            _userManager = userManager;
        }

        public ActionResult Index(string userId)
        {

            //userId = "f28182d3-7db0-4ec7-9dd7-e57014170168";
            var user =  _userManager.Users.Where(u => u.Id == userId).ToList();
            var postedprojects = db.Projects.Where(p => p.CustomerId == userId).Count();
            var accomplishedprojects = db.Projects.Where(p => p.SelectedTranslator == userId && p.Status == "Completed").Count();

            var ProfileInformation = new UserProfileVM
            {

                RateList = (List<Rate>)rateRepository.List(userId),
                UserInfo = user,
                UserId = userId,
                ProjectsCount = postedprojects,
                AccomplishedProjects = accomplishedprojects

            };
            return View(ProfileInformation);
        }
    }
}
