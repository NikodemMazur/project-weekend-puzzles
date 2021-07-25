using ProjectWeekendPuzzles.Security.Authentication;
using System;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public class AuthenticationStateProvider : IAuthenticationStateProvider
    {
        private AuthenticationState _authenticationState;

        public event Action<AuthenticationState> AuthenticationStateChanged;

        public AuthenticationStateProvider(IAuthenticationService authenticationService)
        {
            AuthenticationStateChanged += delegate { };

            var initialUser = authenticationService.LastResult.User;
            _authenticationState = new AuthenticationState(initialUser);

            authenticationService.AuthenticationChanged += result =>
            {
                var newUser = result.User;
                _authenticationState = new AuthenticationState(newUser);
                OnAuthenticationChanged();
            };
        }

        public virtual AuthenticationState GetAuthenticationState()
            => _authenticationState;

        protected virtual void OnAuthenticationChanged()
        {
            AuthenticationStateChanged.Invoke(_authenticationState);
        }
    }
}
