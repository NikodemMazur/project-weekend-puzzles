using Prism.Commands;
using Prism.Mvvm;
using ProjectWeekendPuzzles.Core.MvvmHelpers;

namespace ProjectWeekendPuzzles.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public DelegateCommand<IClosable> CloseCommand { get; }

        public ShellViewModel()
        {
            CloseCommand = new DelegateCommand<IClosable>(Close);
        }

        private static void Close(IClosable obj) => obj.Close();
    }
}
