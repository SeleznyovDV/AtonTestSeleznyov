using System;

namespace Core.Entities
{
    public abstract class AuditableEntity : BaseEntity, IAutitableEntity
    {
        public DateTime CreateOn { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public DateTime? RevokedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; }
        public string RevokedBy { get; private set; }
        public void Create(string createdBy)
        {
            CreateOn = DateTime.Now;
            CreatedBy = createdBy;
        }
        public void Update(string modifedBy)
        {
            ModifiedOn = DateTime.Now;
            ModifiedBy = modifedBy;
        }
        public void Revoke(string revokedBy)
        {
            RevokedOn = DateTime.Now;
            RevokedBy = revokedBy;
        }
        public void UnRevoke()
        {
            RevokedOn = null;
            RevokedBy = null;
        }
        public bool IsDeleted()
        {
            if (RevokedBy == null)
                return false;
            else
                return true;
        }
    }
}
