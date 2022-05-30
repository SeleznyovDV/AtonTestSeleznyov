﻿using Data.Base;
using System;
using System.Text.RegularExpressions;

namespace Data.Validation
{
    public class ValidUserNameSpecification : ValidSpecification<User>
    {
        public override Func<User, bool> ToExpression()
        {
            return user => Regex.IsMatch(user.Name, @"^[a-zA-Zа-яА-Я]+$");
        }
    }
}
