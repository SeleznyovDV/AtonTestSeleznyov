using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class AccessRightsException : ApiException
    {
        public AccessRightsException()
            :base(ExceptionCodes.NoAccessRights, "Not enough access rights")
        { 
        }
    }
}
