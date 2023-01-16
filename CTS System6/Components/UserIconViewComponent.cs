using CTS_System6.Models;
using CTS_System6.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Components
{
    public class ProfileIconViewComponent : ViewComponent
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileIconViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string UserId)
        {

            var users = _userManager.Users.Where(user => user.Id == UserId).Select(user => new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePictuer = user.ProfilePictuer,
                Rate = user.Rate
            }).SingleOrDefault();


            return View(users);
        }
    }
}
