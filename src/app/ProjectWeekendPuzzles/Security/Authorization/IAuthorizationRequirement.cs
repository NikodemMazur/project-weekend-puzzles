using ProjectWeekendPuzzles.Security.Core;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public interface IAuthorizationRequirement
    {
        AuthorizationResult HandleAuthorizationRequest(User user);
    }
}
