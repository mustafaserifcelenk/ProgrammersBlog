using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryUpdateAjaxViewModel
    {
        public CategoryAddDto CategoryUpdateDto { get; set; }
        public string CategoryUpdatePartial { get; set; } // CategoryAddPartial'ı string olarak parse edeceğiz ve ihtiyacımız olduğunda kullanacağız
        public CategoryDto CategoryDto { get; set; }
    }
}
