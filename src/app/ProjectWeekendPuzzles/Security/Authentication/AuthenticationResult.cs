using ProjectWeekendPuzzles.Security.Core;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public class AuthenticationResult
    {
        public static AuthenticationResult Fail(AuthenticationException failure)
            => new(null, failure);

        public static AuthenticationResult Succeed(User user)
            => new(user, null);

        private AuthenticationResult(User? user, AuthenticationException? failure)
        {
            User = user ?? User.Anonymous;
            Success = failure is null;
            Failure = failure;
        }

        public User User { get; }
        public AuthenticationException? Failure { get; }
        public bool Success { get; }
    }
}
