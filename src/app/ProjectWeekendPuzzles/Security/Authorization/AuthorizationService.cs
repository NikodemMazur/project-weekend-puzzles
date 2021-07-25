using ProjectWeekendPuzzles.Security.Core;
using System;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRequirement _requirement;

        public AuthorizationService(IAuthorizationRequirement requirement)
        {
            _requirement = requirement ?? throw new ArgumentNullException(nameof(requirement));
        }

        public virtual AuthorizationResult Authorize(User user)
        {
            return _requirement.HandleAuthorizationRequest(user);
        }
    }
}
