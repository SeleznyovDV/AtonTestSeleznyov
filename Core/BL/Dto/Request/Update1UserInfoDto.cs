using System;

namespace Core.BL.Dto.Request
{
    public class Update1UserInfoDto
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
