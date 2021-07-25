using System;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult SignInAsync(UserCredentials userCredentials, IAuthenticationHandler authenticationHandler);
        AuthenticationResult SignOutAsync(IAuthenticationHandler authenticationHandler);
        event Action<AuthenticationResult> AuthenticationChanged;
        AuthenticationResult LastResult { get; }
    }
}
