---
sidebar_position: 1
---

# Modularity

Modularity has been achieved with *Prism Library*. The library, which actually is an open-source framework, is used explicitly and is not hidden behind any interfaces nor abstracted in any other way. PWP allows a developer to extend its content through creating loosely coupled plugins (aka *Prism's* modules) that meet a contract defined and contained in the PWP's core dll. This way, the second *SOLID* principle is strongly enforced. In addition to modules, PWP also utilizes other *Prism* features such as MVVM helpers, Navigation and Dependency Injection. *Prism* is an extensible framework whose user can easily inject a custom implementation into it; for instance, to have child tabs inside parent tabs, a developer needs to overwrite (through DI registering) the `ScopedRegionNavigationContentLoader` class. *Prism* can be called the "first-framework citizen" as most of the components of PWP are built on the top of it. Therefore it is critical to PWP's developers and users to know each of *Prism's* mechanisms in detail to be able to freely tailor them to the application needs.

:::warning TODO
Update tree and App.config on the third module release to make the structure pattern clearer
:::

Project structure:
```
PROJECT-WEEKEND-PUZZLES\SRC
├───app
│   ├───ProjectWeekendPuzzles
│   │   ├───ApiServer
│   │   ├───ViewModels
│   │   └───Views
│   └───ProjectWeekendPuzzles.Core
│       ├───ApiServer
│       ├───MvvmHelpers
│       ├───ResourceDictionaries
│       └───ViewContract
└───modules
    ├───dashboard
    │   ├───ProjectWeekendPuzzles.Dashboard
    │   │   ├───ViewModels
    │   │   └───Views
    │   ├───ProjectWeekendPuzzles.Dashboard.Api
    │   │   ├───Protos
    │   │   └───Services
    │   ├───ProjectWeekendPuzzles.Dashboard.Client
    │   │   ├───Properties
    │   │   └───Protos
    │   └───ProjectWeekendPuzzles.Dashboard.Model
    └───module-info
        └───ProjectWeekendPuzzles.ModuleInfo
            ├───Model
            ├───Properties
            ├───ViewModels
            └───Views
```
Registration of modules in the app (App.config):
```xml
<configuration>
  <configSections>
    <section name="modules" type="Prism.Modularity.ModulesConfigurationSection, Prism.Wpf" />
  </configSections>
  
  <appSettings>
    <add key="port" value="55331" />
  </appSettings>

  <modules>
    <module assemblyFile="ProjectWeekendPuzzles.ModuleInfo.dll" moduleType="ProjectWeekendPuzzles.ModuleInfo.ModuleInfoModule, ProjectWeekendPuzzles.ModuleInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            moduleName="ModuleInfoModule" startupLoaded="True" />
    <module assemblyFile="ProjectWeekendPuzzles.Dashboard.dll" moduleType="ProjectWeekendPuzzles.Dashboard.DashboardModule, ProjectWeekendPuzzles.Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            moduleName="DashboardModule" startupLoaded="True" />
  </modules>
  
</configuration>
```