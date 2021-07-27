using ProjectWeekendPuzzles.Core.Security.Authorization;

namespace ProjectWeekendPuzzles.Security.Authorization
{
    public class AuthorizationResult
    {
        private AuthorizationResult(AuthorizationException? failure)
        {
            Success = failure is null;
            Failure = failure;
        }

        public static AuthorizationResult Fail(AuthorizationException failure)
            => new(failure);

        public static AuthorizationResult Succeed()
            => new(null);

        public bool Success { get; }
        public AuthorizationException? Failure { get; }
    }
}