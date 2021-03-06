using System;

namespace ProjectWeekendPuzzles.Core.Security.Authorization
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));
        }
    }
}
