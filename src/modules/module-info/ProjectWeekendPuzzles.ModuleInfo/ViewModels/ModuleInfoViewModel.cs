using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Mvvm;
using ProjectWeekendPuzzles.ModuleInfo.Model;

namespace ProjectWeekendPuzzles.ModuleInfo.ViewModels
{
    public class ModuleInfoViewModel : BindableBase
    {
        private string _welcomeText;
        public string WelcomeText
        {
            get => _welcomeText;
            set => SetProperty(ref _welcomeText, value);
        }

        private IEnumerable<ModuleInformation> _moduleInfos;
        public IEnumerable<ModuleInformation> ModuleInfos
        {
            get => _moduleInfos;
            set => SetProperty(ref _moduleInfos, value);
        }

        public ModuleInfoViewModel(ModuleInformationProcessor moduleInformationProcessor)
        {
            WelcomeText = "Hello from the new module!";

            ModuleInfos = moduleInformationProcessor.GetModuleInformation();
        }


    }
}
