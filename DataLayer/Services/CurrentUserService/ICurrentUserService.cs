using Data.CQRS.Dto.Request;

namespace Data.Services.CurrentUserService
{
    public interface ICurrentUserService
    {
        public string GetUserLogin();
        public CurrentUserDto GetUser();
    }
}
