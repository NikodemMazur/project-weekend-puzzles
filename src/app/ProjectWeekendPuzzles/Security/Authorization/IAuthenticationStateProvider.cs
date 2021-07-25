using System;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public interface IAuthenticationStateProvider
    {
        event Action<AuthenticationState> AuthenticationStateChanged;
        AuthenticationState GetAuthenticationState();
    }
}
