using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", await _roleManager.Roles.ToListAsync());
            var roleIsExists = await _roleManager.RoleExistsAsync(model.Name);

            if(roleIsExists)
            {
                ModelState.AddModelError("Name", "Role Is Exists!");
                return View("Index", await _roleManager.Roles.ToListAsync());
            }

            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }
    }
}
