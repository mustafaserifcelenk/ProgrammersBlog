using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent:ViewComponent 
    {
        private readonly UserManager<User> _userManager;

        public AdminMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result; // ViewComponent asenkrona izin vermiyor o yüzden result kullandık
            var roles = _userManager.GetRolesAsync(user).Result;
            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            }); //AdminMenu Shared'da Kendi adında klasör arayacak ve o klasörde de default arayacak
        }
    }
}
