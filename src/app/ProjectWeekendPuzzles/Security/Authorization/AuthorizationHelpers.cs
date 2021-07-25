using System.Linq;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public static class AuthorizationHelpers
    {
        public static RoleAuthorizationRequirement ToRequirement(this object source)
        {
            var roles = source
                .GetType()
                .GetCustomAttributes(typeof(AuthorizeRoleAttribute), false)
                .OfType<AuthorizeRoleAttribute>()
                .Select(x => x.Role);

            return new RoleAuthorizationRequirement(roles);
        }
    }
}
