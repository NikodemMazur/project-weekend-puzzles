using Prism.Commands;
using Prism.Mvvm;
using ProjectWeekendPuzzles.Core.MvvmHelpers;
using ProjectWeekendPuzzles.Security.Authentication;
using ProjectWeekendPuzzles.Security.Core;
using System;

namespace ProjectWeekendPuzzles.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private object _currentAuthenticationViewModel;
        public object CurrentAuthenticationViewModel
        {
            get => _currentAuthenticationViewModel;
            set => SetProperty(ref _currentAuthenticationViewModel, value);
        }

        public DelegateCommand<IClosable> CloseCommand { get; }

        public ShellViewModel(IAuthenticationService authenticationService,
                              Func<SignInViewModel> signInViewModelFactory,
                              Func<SignOutViewModel> signOutViewModelFactory)
        {
            CloseCommand = new DelegateCommand<IClosable>(Close);

            _currentAuthenticationViewModel = signInViewModelFactory();

            authenticationService.AuthenticationChanged += x =>
            {
                if (x.Success && x.User != User.Anonymous)
                    CurrentAuthenticationViewModel = signOutViewModelFactory();
                else
                    CurrentAuthenticationViewModel = signInViewModelFactory();
            };
        }

        private static void Close(IClosable obj) => obj.Close();
    }
}
