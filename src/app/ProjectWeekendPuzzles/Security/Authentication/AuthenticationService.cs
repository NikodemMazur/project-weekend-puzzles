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

        public AuthenticationResult SignIn(UserCredentials userCredentials, IAuthenticationHandler authenticationHandler)
        {
            var result = authenticationHandler.AuthenticateAsync(userCredentials).Result;

            _lastResult = result;
            OnAuthenticationChanged();
            return result;
        }

        public AuthenticationResult SignOut(IAuthenticationHandler authenticationHandler)
        {
            authenticationHandler.SingOut(_lastResult.User);

            var result = AuthenticationResult.Succeed(User.Anonymous);
            _lastResult = result;
            OnAuthenticationChanged();
            return result;
        }
    }
}
