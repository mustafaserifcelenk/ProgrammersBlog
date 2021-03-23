using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserRoleAssignDto
    {
        // Eğer bir listeye teker teker eleman atayacaksak bunu başta initialize etmemiz gerekir, ama direk bu IList'e direk liste atayacaksak initialize etmemize gerek olmaz. Bunun sebebi IList olarak bir interface kullanmamızdır.
        public UserRoleAssignDto()
        {
            RoleAssignDtos = new List<RoleAssignDto>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<RoleAssignDto> RoleAssignDtos { get; set; }
    }
}
