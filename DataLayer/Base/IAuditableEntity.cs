using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IAutitableEntity
    {
        public void Create(string createdBy);

        public void Update(string ModifedBy);

        public void Revoke(string revokedBy);

    }
}
