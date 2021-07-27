using Prism.Commands;
using Prism.Mvvm;
using ProjectWeekendPuzzles.Security.Authentication;
using System;

namespace ProjectWeekendPuzzles.ViewModels
{
    public class SignInViewModel : BindableBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthenticationHandler _authenticationHandler;

        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand SignInCommand { get; }

        public SignInViewModel(IAuthenticationService authenticationService, IAuthenticationHandler authenticationHandler)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _authenticationHandler = authenticationHandler ?? throw new ArgumentNullException(nameof(authenticationHandler));

            SignInCommand = new DelegateCommand(SignIn);
        }

        private void SignIn()
        {
            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Password))
                return;

            var userCredentials = new UserCredentials(Name, Password);
            _ = _authenticationService.SignIn(userCredentials, _authenticationHandler);
        }
    }
}
