using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectWeekendPuzzles.ModuleInfo.Model
{
    public class ModuleInformationProcessor
    {
        private readonly IModuleCatalog _moduleCatalog;

        public ModuleInformationProcessor(IModuleCatalog moduleCatalog)
        {
            _moduleCatalog = moduleCatalog;
        }

        public IEnumerable<ModuleInformation> GetModuleInformation()
        {
            Func<IModuleInfo, string> assemblyNameGetter = x => x.ModuleType.Split(",")[1].Trim();
            Func<IModuleInfo, string> assemblyVerGetter = x => x.ModuleType.Split(",")[2].Trim();
            Func<IModuleInfo, string> moduleNameGetter = x => x.ModuleName;

            return _moduleCatalog.Modules.Select(x => new ModuleInformation(moduleNameGetter(x),
                assemblyNameGetter(x),
                assemblyVerGetter(x)));
        }
    }
}
