using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto UserUpdateDto { get; set; }
        public string UserUpdatePartial { get; set; } // CategoryAddPartial'ı string olarak parse edeceğiz ve ihtiyacımız olduğunda kullanacağız
        public UserDto UserDto { get; set; }
    }
}
