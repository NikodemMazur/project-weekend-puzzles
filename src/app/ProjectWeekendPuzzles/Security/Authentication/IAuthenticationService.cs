using System;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult SignIn(UserCredentials userCredentials, IAuthenticationHandler authenticationHandler);
        AuthenticationResult SignOut(IAuthenticationHandler authenticationHandler);
        event Action<AuthenticationResult> AuthenticationChanged;
        AuthenticationResult LastResult { get; }
    }
}
