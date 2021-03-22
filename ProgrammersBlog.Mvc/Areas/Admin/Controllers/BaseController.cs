using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // Sadece get olma sebebi farklı bir sınıfın bunları değiştirmesini istemiyoruz
        protected UserManager<User> UserManager { get; }
        protected IMapper Mapper { get; }
        protected IImageHelper ImageHelper { get; }
        // BaseController'dan türemiş tüm controllerlarda Log in olmuş usera erişebileceğiz
        protected User LoggedInUser => UserManager.GetUserAsync(HttpContext.User).Result;

        public BaseController(IImageHelper ımageHelper, IMapper mapper, UserManager<User> userManager)
        {
            ImageHelper = ımageHelper;
            Mapper = mapper;
            UserManager = userManager;
        }
    }
}
