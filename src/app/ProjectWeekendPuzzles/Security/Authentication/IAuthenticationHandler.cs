using ProjectWeekendPuzzles.Security.Core;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public interface IAuthenticationHandler
    {
        Task<AuthenticationResult> AuthenticateAsync(UserCredentials userCredentials);
        Task SingOut(User user);
    }
}