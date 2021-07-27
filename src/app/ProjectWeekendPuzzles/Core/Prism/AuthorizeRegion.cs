using Prism.Regions;
using ProjectWeekendPuzzles.Security.Authorization;

namespace ProjectWeekendPuzzles.Core.Prism
{
    public class AuthorizeRegion : Region
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IAuthenticationStateProvider _authenticationState;

        private bool IsUserAuthorizedFor(object view)
        {
            var requirement = view.ToRequirement();
            var authState = _authenticationState.GetAuthenticationState();
            var user = authState.User;
            var result = _authorizationService.Authorize(user, requirement);
            return result.Success;
        }

        public AuthorizeRegion(IAuthorizationService authorizationService, IAuthenticationStateProvider authenticationState) : base()
        {
            _authorizationService = authorizationService ?? throw new System.ArgumentNullException(nameof(authorizationService));
            _authenticationState = authenticationState ?? throw new System.ArgumentNullException(nameof(authenticationState));
        }

        public override IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
        {
            if (IsUserAuthorizedFor(view))
                return base.Add(view, viewName, createRegionManagerScope);
            else
                return RegionManager;
        }
    }
}
