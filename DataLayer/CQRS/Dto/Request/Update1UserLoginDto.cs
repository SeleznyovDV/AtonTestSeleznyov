﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Dto.Request
{
    public class Update1UserLoginDto
    {
        public CurrentUserDto CurrentUser { get; set; }
        public string Login { get; set; }
        public string NewLogin { get; set; }
    }
}
