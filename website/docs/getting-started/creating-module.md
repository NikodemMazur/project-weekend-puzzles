---
sidebar_position: 3
---

# Creating module

To better tell what is necessary for a piece of code to be a ProjectWeekendPuzzles' module, the guide has been split into two parts. The first one shows the minimum steps to plug a view into the application. The first part results in a blank view injected into the `main-content-region` of the application. In the other part, a user is guided to provide a reactive content that is controlled through gRPC API. Upon completing the guide, a user has enough knowledge to create a module that can do anything a normal WPF application can.

:::tip How to follow this guide
Do not skip any steps. A text instruction is followed (or not) by a related graphic; never the other way round
:::

## Creating a blank module

This part shows how to inject a blank view into the application using *WPF*, *Prism*, *Material Design*, and *ProjectWeekendPuzzles.Core.dll*

### Create a project

Open Visual Studio and create a new *WPF User Control Library* project

![Project type](/img/getting-started/new-project-type.png)

- Set the project name to `ProjectWeekendPuzzles.<YourModule>`
- Set the project location to: `<your-repo-folder>\project-weekend-puzzles\src\modules`
- Set the solution name to `<your-module>` (Note the different naming conventions, `<YourModule>`, `<your-module>`)

![Project configuration](/img/getting-started/new-project-names.png)

Choose .NET 5 for Windows

![Project target](/img/getting-started/new-project-target.png)

### Remove the auto-generated control `UserControl1.xaml`

For the purpose of this guide, we are going to create everything from scratch. Remove the user control the project scaffolding has created

### Create Views and ViewModels folders

![View and ViewModels folders](/img/getting-started/add-folders.png)

### To Views folder, add a new User Control (WPF)

![User Control (WPF)](/img/getting-started/add-user-control-to-project.png)

And name it `<YourModule>View`

### Create dummy content

Add `MaterialDesign` package references

![Material Design package references](/img/getting-started/add-materialdesign-references.png)

- Add `materialDesign` namespace
- Add following resource dictionaries (to use `MaterialDesign` controls and icons)

```xml {7,11-18,21-24} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\Views\StepListView.xaml"
<UserControl x:Class="ProjectWeekendPuzzles.StepList.Views.StepListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:ProjectWeekendPuzzles.StepList"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    
    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <materialDesign:BundledTheme BaseTheme="{x:Null}" PrimaryColor="DeepPurple" SecondaryColor="Yellow"  />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
    
    <Grid>
        <TextBlock Text="Hello from my new module!"
                   Style="{DynamicResource MaterialDesignHeadline3TextBlock}"
                   VerticalAlignment="Center"
                   TextAlignment="Center" />
    </Grid>
    
</UserControl>
```

Optionally, build the project now to verify that everything is fine so far

### Add new class named `<YourModule>Module`

![New class](/img/getting-started/add-new-class.png)

Add Prism.Wpf package reference

![Prism.Wpf package reference](/img/getting-started/add-prism-wpf-reference.png)

- Make the class `public`
- Implement `IModule`
- Remove `throw`s
- Create ctor and ask for `IRegionManager` service there
- In `OnInitialized` register `<YourModule>View` in `main-content-region` region

```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\StepListModule.cs"
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.StepList.Views;

namespace ProjectWeekendPuzzles.StepList
{
    public class StepListModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public StepListModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion<StepListView>("main-content-region");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}

```

### Implement `IHeadered`

Add the project reference to ProjectWeekendPuzzles.dll; it can be found here:
```none
..\..\..\..\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows\ProjectWeekendPuzzles.Core.dll
```

![Project reference](/img/getting-started/add-project-references.png)

Upon successful addition, the project dependencies should look like this

![Project reference added](/img/getting-started/project-reference-added.png)

Merge the following resource dictionary that contains predefined icon sizes used throughout the application

```xml {16} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\Views\StepListView.xaml"
<UserControl x:Class="ProjectWeekendPuzzles.StepList.Views.StepListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:ProjectWeekendPuzzles.StepList"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    
    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <materialDesign:BundledTheme BaseTheme="{x:Null}" PrimaryColor="DeepPurple" SecondaryColor="Yellow"  />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
                <ResourceDictionary Source="pack://application:,,,/ProjectWeekendPuzzles.Core;component/ResourceDictionaries/Dimensions.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
    
    <Grid>
        <TextBlock Text="Hello from my new module!"
                   Style="{DynamicResource MaterialDesignHeadline3TextBlock}"
                   VerticalAlignment="Center"
                   TextAlignment="Center" />
    </Grid>
    
</UserControl>
```

Go to the view's code-behind and implement the `IHeadered` interface

```csharp {1-2,11,13,19-22,25} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\Views\StepListView.xaml.cs"
using MaterialDesignThemes.Wpf;
using ProjectWeekendPuzzles.Core.ViewContract;
using System;
using System.Windows.Controls;

namespace ProjectWeekendPuzzles.StepList.Views
{
    /// <summary>
    /// Interaction logic for StepListView.xaml
    /// </summary>
    public partial class StepListView : UserControl, IHeadered
    {
        private readonly PackIcon _navigationIcon;

        public StepListView()
        {
            InitializeComponent();

            var iconSize = (double)FindResource("IconSize"); // Works only if ResourceDictionary component has been initialized before
                                                             // (has been referenced in xaml and FindResource method has been called after InitializeComponent)
                                                             // Another interesting approach of referencing resource in code-behind: https://stackoverflow.com/a/24286059
            _navigationIcon = new PackIcon { Kind = Enum.Parse<PackIconKind>("ListStatus"), Width = iconSize, Height = iconSize };
        }

        public object TabHeader => _navigationIcon;
    }
}
```

### Set up deploy

Add the `xcopy` post-build action to put your module dlls in the folder which the main application lives in

![Project properties](/img/getting-started/project-properties.png)

![Post-build event command](/img/getting-started/post-build-event-command.png)

```powershell title="Post-build event command of ProjectWeekendPuzzles.StepList.csproj"
xcopy "$(TargetDir)*.*" "$(SolutionDir)..\..\..\src\app\ProjectWeekendPuzzles\$(OutDir)" /Y /I
```
Force copying dependent dlls to the main application folder

```xml {6} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\ProjectWeekendPuzzles.StepList.csproj"
...

  <PropertyGroup>
    <TargetFramework>net5.0-windows</TargetFramework>
    <UseWPF>true</UseWPF>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
  </PropertyGroup>

...
```

:::info
It is not an elegant way to manage PWP modules. In the target application one should consider extending the Prism's module loading mechanism with something like `NugetModuleCatalog`.
:::

### Add module reference in the application App.config

```xml {12-13} title="\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows\ProjectWeekendPuzzles.dll.config"
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="modules" type="Prism.Modularity.ModulesConfigurationSection, Prism.Wpf" />
  </configSections>
  
  <appSettings>
    <add key="port" value="55331" />
  </appSettings>

  <modules>
	<module assemblyFile="ProjectWeekendPuzzles.StepList.dll" moduleType="ProjectWeekendPuzzles.StepList.StepListModule, ProjectWeekendPuzzles.StepList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            moduleName="StepListModule" startupLoaded="True" />
    <module assemblyFile="ProjectWeekendPuzzles.ModuleInfo.dll" moduleType="ProjectWeekendPuzzles.ModuleInfo.ModuleInfoModule, ProjectWeekendPuzzles.ModuleInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            moduleName="ModuleInfoModule" startupLoaded="True" />
    <module assemblyFile="ProjectWeekendPuzzles.Dashboard.dll" moduleType="ProjectWeekendPuzzles.Dashboard.DashboardModule, ProjectWeekendPuzzles.Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            moduleName="DashboardModule" startupLoaded="True" />
  </modules>
  
</configuration>
```

### Set the project debug properties

Visual Studio allows for debugging a project through another executable. The project weekend puzzles' development style highly benefits from this feature as a single module cannot be run on its own.

![Project debug properties](/img/getting-started/debug-options.png)

```none title="Executable path in ProjectWeekendPuzzles.StepList.csproj Debug properties"
<your-repo-folder>\project-weekend-puzzles\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows\ProjectWeekendPuzzles.exe
```

```none title="Working directory in ProjectWeekendPuzzles.StepList.csproj Debug properties"
<your-repo-folder>\project-weekend-puzzles\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows
```

### Run the project

Run your project and see the application with your module loaded

![Module loaded](/img/getting-started/module-loaded.png)