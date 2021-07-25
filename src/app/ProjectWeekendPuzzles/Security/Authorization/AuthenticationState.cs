using ProjectWeekendPuzzles.Security.Core;
using System;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public class AuthenticationState
    {
        public AuthenticationState(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public User User { get; }
    }
}
