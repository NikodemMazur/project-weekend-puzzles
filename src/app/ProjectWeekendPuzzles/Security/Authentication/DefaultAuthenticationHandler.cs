using ProjectWeekendPuzzles.Security.Core;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    /// <summary>
    /// Default <see cref="IAuthenticationHandler"/> for demo purposes. It follows naming convention username-role0-role1-... and so on.
    /// For example, for joe-developer-maintainer, this class assigns a user the Developer and Maintainer roles.
    /// </summary>
    public class DefaultAuthenticationHandler : IAuthenticationHandler
    {
        public virtual Task<AuthenticationResult> AuthenticateAsync(UserCredentials userCredentials)
        {
            var roles = Enumerable.Empty<string>();
            var nameParts = userCredentials.Name.Split("-");
            if (nameParts.Length > 1)
                roles = nameParts.TakeLast(nameParts.Length - 1);
            var user = new User(userCredentials.Name, roles);
            return Task.FromResult(AuthenticationResult.Succeed(user));
        }

        public Task SingOut(User user)
        {
            return Task.CompletedTask;
        }
    }
}
