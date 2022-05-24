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
    public class ProjectsController : Controller
    {
        private readonly ITranslatorRepository<Projects> projectRepository;

        public ProjectsController(ITranslatorRepository<Projects> projectRepository)
        {
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
            return View();
        }

        // GET: ProjectsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
