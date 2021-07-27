using Prism.Commands;
using Prism.Mvvm;
using ProjectWeekendPuzzles.Security.Authentication;
using ProjectWeekendPuzzles.Security.Core;
using System;

namespace ProjectWeekendPuzzles.ViewModels
{
    public class SignOutViewModel : BindableBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthenticationHandler _authenticationHandler;

        private string? _userName;
        public string? UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public DelegateCommand SignOutCommand { get; }

        public SignOutViewModel(IAuthenticationService authenticationService, IAuthenticationHandler authenticationHandler)
        {
            _authenticationService = authenticationService ?? throw new System.ArgumentNullException(nameof(authenticationService));
            _authenticationHandler = authenticationHandler ?? throw new System.ArgumentNullException(nameof(authenticationHandler));

            SignOutCommand = new DelegateCommand(SignOut);

            UserName = _authenticationService.LastResult.User.Name;
        }

        private void SignOut()
        {
            _ = _authenticationService.SignOut(_authenticationHandler);
        }
    }
}
