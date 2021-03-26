using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;

        // IOptions bizler için gerekli section'ı okuyor ve burada istemiş olduğumuz sınıfa bunları dolduruyor, appsettings.json dan veri okumak istenildiğinde bu her yerde kullanılabilir
        public HomeController(IArticleService articleService, IOptions<AboutUsPageInfo> aboutUsPageInfo)
        {
            _articleService = articleService;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var articlesResult = await (categoryId == null
                ? _articleService.GetAllByPagingAsync(null, currentPage, pageSize, isAscending)
                : _articleService.GetAllByPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));
            return View(articlesResult.Data);
        }

        [HttpGet]
        public async Task<IActionResult> About()
        {
            //throw new Exception("Hata!");
            //throw new NullReferenceException();
            return View(_aboutUsPageInfo);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            return View();
        }
    }
}
