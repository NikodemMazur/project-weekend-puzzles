using ProjectWeekendPuzzles.Security.Core;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public interface IAuthorizationService
    {
        AuthorizationResult Authorize(User user);
    }
}
