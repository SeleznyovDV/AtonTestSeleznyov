using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Dto.Request
{
    public class GetUserDto
    {
        public CurrentUserDto CurrentUser { get; set; }
        public string Login { get; set; }
    }
}
