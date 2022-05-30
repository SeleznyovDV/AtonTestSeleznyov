using System;

namespace Data.CQRS
{
    public class AccessRightsAttribute : Attribute
    {

        public string Permission { get; }
        public AccessRightsAttribute(string permission)
        {
            Permission = permission;
        }
    }
}
