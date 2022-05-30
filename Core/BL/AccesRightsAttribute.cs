using System;

namespace Core.BL
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
