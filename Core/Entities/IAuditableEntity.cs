namespace Core.Entities
{
    public interface IAutitableEntity
    {
        public void Create(string createdBy);

        public void Update(string ModifedBy);

        public void Revoke(string revokedBy);

    }
}
