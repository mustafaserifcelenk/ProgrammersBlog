using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll(); // CategoryService içerisinde bir dataresult dönüyoruz ve dönen bu result success ise ona göre işlem yapacağız, o yüzden bu dataresult'ı var result olarak almış olduk
            //if (result.ResultStatus == ResultStatus.Success)
            //{
            //    return View(result.Data);
            //}
            return View(result.Data); //CategoryManager'da yaptığımız işlem bize bu işi yukarıdaki if yardımıyla controller içinde olayı çözmenin dışında sadece View'a result.Data göndererek view'da bu işi çözmeyi sağladı. 
        }
    }
}
