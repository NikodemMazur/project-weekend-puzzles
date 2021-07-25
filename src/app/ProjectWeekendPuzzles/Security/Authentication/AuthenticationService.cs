using ProjectWeekendPuzzles.Security.Core;
using System;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private AuthenticationResult _lastResult;

        private void OnAuthenticationChanged()
        {
            AuthenticationChanged.Invoke(_lastResult!);
        }

        public AuthenticationService()
        {
            AuthenticationChanged += delegate { };
            _lastResult = AuthenticationResult.Succeed(User.Anonymous);
        }

        public AuthenticationResult LastResult => _lastResult;

        public event Action<AuthenticationResult> AuthenticationChanged;

        public AuthenticationResult SignInAsync(UserCredentials userCredentials, IAuthenticationHandler authenticationHandler)
        {
            var result = authenticationHandler.AuthenticateAsync(userCredentials).Result;

            _lastResult = result;
            OnAuthenticationChanged();
            return result;
        }

        public AuthenticationResult SignOutAsync(IAuthenticationHandler authenticationHandler)
        {
            var result = AuthenticationResult.Succeed(User.Anonymous);

            _lastResult = result;
            authenticationHandler.SingOut(_lastResult.User);
            OnAuthenticationChanged();
            return result;
        }
    }
}
