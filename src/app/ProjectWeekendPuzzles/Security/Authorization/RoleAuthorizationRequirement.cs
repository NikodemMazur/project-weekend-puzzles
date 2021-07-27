using ProjectWeekendPuzzles.Core.Security.Authorization;
using ProjectWeekendPuzzles.Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public class RoleAuthorizationRequirement : IAuthorizationRequirement
    {
        private readonly IEnumerable<string> _allowedRoles;

        public RoleAuthorizationRequirement(IEnumerable<string> allowedRoles)
        {
            _allowedRoles = allowedRoles ?? throw new ArgumentNullException(nameof(allowedRoles));
        }

        public AuthorizationResult HandleAuthorizationRequest(User user)
        {
            if (!_allowedRoles.Any())
                return AuthorizationResult.Succeed();

            var allowedRolesLc = _allowedRoles.Select(x => x.ToLower());

            return allowedRolesLc
                .Intersect(user.Roles.Select(x => x.ToLower()))
                .Any()
                ? AuthorizationResult.Succeed()
                : AuthorizationResult.Fail(new AuthorizationException($"User not in following roles: {String.Join(", ", _allowedRoles)}"));
        }
    }
}
