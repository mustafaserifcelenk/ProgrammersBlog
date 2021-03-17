using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto { get; set; }
        public string UserAddPartial { get; set; } // CategoryAddPartial'ı string olarak parse edeceğiz ve ihtiyacımız olduğunda kullanacağız
        public UserDto UserDto { get; set; }
    }
}
