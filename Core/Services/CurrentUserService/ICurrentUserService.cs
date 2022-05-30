using Core.BL.Dto.Request;

namespace Core.Services.CurrentUserService
{
    public interface ICurrentUserService
    {
        public string GetUserLogin();
        public CurrentUserDto GetUser();
    }
}
