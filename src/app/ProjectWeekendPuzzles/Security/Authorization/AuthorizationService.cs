using ProjectWeekendPuzzles.Security.Core;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        public virtual AuthorizationResult Authorize(User user, IAuthorizationRequirement authorizationRequirement)
        {
            return authorizationRequirement.HandleAuthorizationRequest(user);
        }
    }
}
