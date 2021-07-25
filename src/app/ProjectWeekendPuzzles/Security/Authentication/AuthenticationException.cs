using System;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));
        }
    }
}
