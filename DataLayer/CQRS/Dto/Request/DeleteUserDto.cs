﻿namespace Data.CQRS.Dto.Request
{
    public class DeleteUserDto
    {
        public string Login { get; set; }
        public bool SoftRemoval { get; set; }
    }
}
