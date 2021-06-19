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

### Create a main project

- Open Visual Studio and create a new *WPF User Control Library* project

![Project type](/img/getting-started/new-project-type.png)

- Set the project name to `ProjectWeekendPuzzles.<YourModule>`
- Set the project location to: `<your-repo-folder>\project-weekend-puzzles\src\modules`
- Set the solution name to `<your-module>` (Note the different naming conventions, `<YourModule>`, `<your-module>`)

![Project configuration](/img/getting-started/new-project-names.png)

- Choose .NET 5 for Windows

![Project target](/img/getting-started/new-project-target.png)

For the purpose of this guide, we are going to create everything from scratch.

- Remove the user control the project scaffolding has created. Next, create `Views` and `ViewModels` folders

![View and ViewModels folders](/img/getting-started/add-folders.png)

### Create a simple view

- To `Views` folder, add a new User Control (WPF) and name it `<YourModule>View`

![User Control (WPF)](/img/getting-started/add-user-control-to-project.png)

- Add `MaterialDesign` package references

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

Optionally, build the project to verify that everything is fine so far

### Create a module class

- Add a new class named `<YourModule>Module`

![New class](/img/getting-started/add-new-class.png)

- Add `Prism.Wpf` package reference

![Prism.Wpf package reference](/img/getting-started/add-prism-wpf-reference.png)

- Make the class `public`
- Implement `IModule`
- Remove `throw`s
- Create ctor and ask for `IRegionManager` service
- In the `OnInitialized` method register `<YourModule>View` in the `main-content-region` region

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

A view that is registered in the `main-content-region` region must meet a contract defined by `IHeadered` interface which, as its name suggests, forces an implementation to provide an object that will represent a tab header.

- Add the project reference to ProjectWeekendPuzzles.dll; it can be found here:
```none
..\..\..\..\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows\ProjectWeekendPuzzles.Core.dll
```

![Project reference](/img/getting-started/add-project-references.png)

- Upon successful addition, the project dependencies should look like this

![Project reference added](/img/getting-started/project-reference-added.png)

- Merge the following resource dictionary that contains predefined icon sizes used throughout the application

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

- Go to the view's code-behind and implement the `IHeadered` interface

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

### Set up the deploy

Upon a successful build, our assemblies should be moved to the place where the *ProjectWeekendPuzzles.exe* executable is located

- Add the `xcopy` post-build action to put your module dlls in the folder which the main application lives in

![Project properties](/img/getting-started/project-properties.png)

![Post-build event command](/img/getting-started/post-build-event-command.png)

```powershell title="Post-build event command of ProjectWeekendPuzzles.StepList.csproj"
xcopy "$(TargetDir)*.*" "$(SolutionDir)..\..\..\src\app\ProjectWeekendPuzzles\$(OutDir)" /Y /I
```
- Force copying dependent dlls to the main application folder

```xml {6} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\ProjectWeekendPuzzles.StepList.csproj"
...

  <PropertyGroup>
    <TargetFramework>net5.0-windows</TargetFramework>
    <UseWPF>true</UseWPF>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
  </PropertyGroup>

...
```

:::tip
Yeah, you are right, that is not an elegant way of delivering modules. In the target application one should consider extending the Prism's module loading mechanism with something like `NugetModuleCatalog`
:::

### Add the module to the application

The application does not have any discovery mechanisms. You have to tell it what modules it should load

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

### Run the project

Visual Studio allows for debugging a project through another executable. The project weekend puzzles' development style highly benefits from this feature as a single module cannot be run on its own

- Set the project debug properties as in the picture below

![Project debug properties](/img/getting-started/debug-options.png)

```none title="Executable path in ProjectWeekendPuzzles.StepList.csproj Debug properties"
<your-repo-folder>\project-weekend-puzzles\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows\ProjectWeekendPuzzles.exe
```

```none title="Working directory in ProjectWeekendPuzzles.StepList.csproj Debug properties"
<your-repo-folder>\project-weekend-puzzles\src\app\ProjectWeekendPuzzles\bin\Debug\net5.0-windows
```

- Run your project and see the application with your module loaded

![Module loaded](/img/getting-started/module-loaded.png)










## Providing reactive content

This part will guide you through providing a reactive content. The interactions between **M**, **V**, and **VM** will be implemented thoroughly with the Observer Pattern. Once the model along with UI is ready, a connection with the outside world will be established with a use of gRPC.

### Create a model

- Create a new .NET Core class library project and name it `ProjectWeekendPuzzles.<YourModule>.Model`. Modify the `<TargetFramework>` element so that the project targets Windows.

```xml {4} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Model\ProjectWeekendPuzzles.StepList.Model.csproj"
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net5.0-windows</TargetFramework>
  </PropertyGroup>

</Project>
```

- Add a class that will carry information about a single step. Use C# 9.0 `record`s for the auto-overriden equality semantics that will be useful when making an `ObservableCollection<T>` from `IObservable<T>`. The property `Id` of type `Guid` is introduced to let for duplicates in an `ObservableCollection<T>`

```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Model\Step.cs"
using System;

namespace ProjectWeekendPuzzles.StepList.Model
{
    public record Step
    {
        public Step(string name, string result, StepStatus status)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Result = result ?? throw new ArgumentNullException(nameof(result));
            Status = status;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Result { get; }
        public StepStatus Status { get; }

        public enum StepStatus
        {
            Pass,
            Fail,
            Error
        };
    }
}
```

- Create an entity that will be shared (as a singleton instance) between the API service and the view model. Let it be mutable to limit the IPC traffic. Add two essential methods that allow for populating and clearing a viewed list.

```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Model\StepListModel.cs"
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ProjectWeekendPuzzles.StepList.Model
{
    public class StepListModel
    {
        private readonly ConcurrentQueue<Step> _steps = new();

        public void AddSteps(IEnumerable<Step> steps)
        {
            steps
                .ToList()
                .ForEach(x => _steps.Enqueue(x));
        }

        public void Clear()
        {
            _steps.Clear();
        }
    }
}
```

:::info
You may wonder why the heck do you need a separate project for a couple of classes? Well, theoretically you do not. However, things get complicated when gRPC tools are used along with the WPF project. You will learn the motivation for this approach when creating the API project later
:::

- Let's use the `IObservable<T>` interface to let the model notify listeners about its state changes. As implementing `IObservable<T>` is rather cumbersome, a more convenient approach is to use the reactive extensions to do that. Add a package reference to `System.Reactive` and use the `Observable.FromEvent<T>` method to create an `IObservable<T>` that is controlled through .NET `event`s. This method converts Action-based `event` to an observable sequence and is the fastest way to implement the Observer Pattern in our case.

```csharp {5,9,11-12,15-19,27,34,37} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Model\StepListModel.cs"
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace ProjectWeekendPuzzles.StepList.Model
{
    public class StepListModel : IObservable<IEnumerable<Step>>
    {
        private readonly IObservable<IEnumerable<Step>> _observable;
        private event Action<IEnumerable<Step>> ListChanged;
        private readonly ConcurrentQueue<Step> _steps = new();

        public StepListModel()
        {
            ListChanged += _ => { };
            _observable = Observable.FromEvent<IEnumerable<Step>>(a => ListChanged += a, a => ListChanged -= a);
        }

        public void AddSteps(IEnumerable<Step> steps)
        {
            steps
                .ToList()
                .ForEach(x => _steps.Enqueue(x));

            ListChanged.Invoke(_steps);
        }

        public void Clear()
        {
            _steps.Clear();

            ListChanged.Invoke(_steps);
        }

        public IDisposable Subscribe(IObserver<IEnumerable<Step>> observer) => _observable.Subscribe(observer);
    }
}
```

- Once you finish the model, register it as a singleton in the IoC. Do not forget about referencing the model project to make its namespace accessible in the `<YourModule>Module` class.

```csharp {4,25} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\StepListModule.cs"
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.StepList.Model;
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
            containerRegistry.RegisterSingleton<StepListModel>();
        }
    }
}
```

### Create a view model

Having the model defined and implemented, it is time to subscribe to it. We will use `DynamicData` and `ReactiveUI` packages to easily write a logic that keeps track of changes of the model. This way, both the view model and the view will be updated by observables.

- Port `IObservable<IEnumerable<T>>` to `ObservableCollection<T>` with `IChangeSet<T>`. This way, produced `ReadOnlyObservableCollection<T>` will be fully reactive which let a WPF control render only newly added items rather than them all

```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\ViewModels\StepListViewModel.cs"
using DynamicData;
using DynamicData.Binding;
using ProjectWeekendPuzzles.StepList.Model;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace ProjectWeekendPuzzles.StepList.ViewModels
{
    public class StepListViewModel : ReactiveObject
    {
        private ReadOnlyObservableCollection<Step> _stepList;
        public ReadOnlyObservableCollection<Step> StepList => _stepList;

        public StepListViewModel(StepListModel stepListModel)
        {
            stepListModel
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToObservableChangeSet(x => x.Id)
                .IgnoreUpdateWhen((curr, prev) => curr.Equals(prev)) // The whole IChangeSet is said to be updated every time a new item is added though the old items remained 
                .Bind(out _stepList)                                 // unchanged. To prevent an unnecessary rendering of items one should explicitly discard updates with a simple predicate.
                .Subscribe();
        }
    }
}
```

- To enable the Prism's view model location, go to the .xaml and set `AutoWireViewModel` to `True`

```xml {8-9} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\Views\StepListView.xaml"
<UserControl x:Class="ProjectWeekendPuzzles.StepList.Views.StepListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:ProjectWeekendPuzzles.StepList"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
             xmlns:prism="http://prismlibrary.com/"
             prism:ViewModelLocator.AutoWireViewModel="True"
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

### Reimplement the view

- Add `ListBox` control and equip it with a small set of additional functionalities to improve the UX. Use `ReactiveUI`'s disposable type-safe bindings

```xml title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\Views\StepListView.xaml"
<views:StepListViewBase x:Class="ProjectWeekendPuzzles.StepList.Views.StepListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:ProjectWeekendPuzzles.StepList"
             xmlns:views="clr-namespace:ProjectWeekendPuzzles.StepList.Views"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
             xmlns:prism="http://prismlibrary.com/"
             xmlns:diag="clr-namespace:System.Diagnostics;assembly=WindowsBase"
             prism:ViewModelLocator.AutoWireViewModel="True"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    
    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <materialDesign:BundledTheme BaseTheme="{x:Null}" PrimaryColor="DeepPurple" SecondaryColor="Yellow"  />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
                <ResourceDictionary Source="pack://application:,,,/ProjectWeekendPuzzles.Core;component/ResourceDictionaries/Dimensions.xaml" />
            </ResourceDictionary.MergedDictionaries>
            <Style TargetType="materialDesign:ColorZone">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Status}" Value="Pass">
                        <Setter Property="Background" Value="Green" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Status}" Value="Fail">
                        <Setter Property="Background" Value="Crimson" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Status}" Value="Error">
                        <Setter Property="Background" Value="BlueViolet" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ResourceDictionary>
        
    </UserControl.Resources>
    
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <materialDesign:Card Margin="29,13,32,10"
                             UniformCornerRadius="2">

            <Grid Margin="8,10,33,10">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="1*" />
                        <ColumnDefinition Width="1*" />
                        <ColumnDefinition Width="0.15*" />
                    </Grid.ColumnDefinitions>
                    
                    <TextBlock Text="Name"
                               TextAlignment="Left" />

                    <TextBlock Text="Result"
                               TextAlignment="Left"
                               Grid.Column="1" />

                    <TextBlock Text="Status"
                               TextAlignment="Left"
                               Grid.Column="2" />
                </Grid>
                
        </materialDesign:Card>

        <ScrollViewer Grid.Row="1"
                      Margin="24 2 2 2"
                      materialDesign:ScrollViewerAssist.IgnorePadding="False"
                      materialDesign:ScrollViewerAssist.IsAutoHideEnabled="True"
                      Style="{DynamicResource MaterialDesignScrollViewer}"
                      Name="ScrollViewer"
                      ScrollChanged="ScrollViewer_ScrollChanged"
                      PreviewMouseWheel="ScrollViewer_PreviewMouseWheel"
                      CanContentScroll="True">

            <ListBox x:Name="Steps"
                     Visibility="Visible"
                     Style="{DynamicResource MaterialDesignCardsListBox}"
                     Margin="5">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>

                        <Border Padding="8"
                                    Name="ItemBorder"
                                    BorderThickness="0 0 0 1"
                                    BorderBrush="{DynamicResource MaterialDesignDivider}">

                                <Grid x:Name="ItemsControlGrid">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="1*" />
                                        <ColumnDefinition Width="1*" />
                                        <ColumnDefinition Width="0.2*" />
                                    </Grid.ColumnDefinitions>

                                    <TextBlock Text="{Binding Name}"
                                       VerticalAlignment="Center" />

                                    <TextBlock Text="{Binding Result}"
                                       VerticalAlignment="Center"
                                       Grid.Column="1" />

                                    <ContentControl HorizontalAlignment="Stretch"
                                            Grid.Column="2">
                                        <materialDesign:ColorZone materialDesign:ShadowAssist.ShadowDepth="Depth2"
                                                          CornerRadius="5"
                                                          Padding="8">
                                            <TextBlock Text="{Binding Status}"
                                               TextAlignment="Center" />
                                        </materialDesign:ColorZone>
                                    </ContentControl>

                                </Grid>
                            
                            </Border>
                        
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ListBox>
            
        </ScrollViewer>
        
    </Grid>
    
</views:StepListViewBase>
```

:::note
In the .xaml above, two types of bindings have been combined together; the `ReactiveUI` type-safe bindings (through explicitly named control `Steps`) and the traditional XAML markup bindings with `{Binding XXX}`. However, it is a good practice to choose only one approach and stick to it throughout the development
:::

```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\Views\StepListView.xaml.cs"
using MaterialDesignThemes.Wpf;
using Prism.Regions;
using ProjectWeekendPuzzles.Core.ViewContract;
using ProjectWeekendPuzzles.StepList.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ProjectWeekendPuzzles.StepList.Views
{
    public class StepListViewBase : ReactiveUserControl<StepListViewModel> { }

    /// <summary>
    /// Interaction logic for StepListView.xaml
    /// </summary>
    [RegionMemberLifetime(KeepAlive = true)]
    public partial class StepListView : StepListViewBase, IHeadered
    {
        private readonly PackIcon _navigationIcon;

        private readonly ColorAnimation _newItemAnimation = new() { To = Colors.Yellow, Duration = new Duration(TimeSpan.FromMilliseconds(300)), AutoReverse = true };

        public StepListView()
        {
            InitializeComponent();

            #region ReactiveUI type-safe bindings

            this.WhenActivated(disposableRegistration =>
            {
                ViewModel = (StepListViewModel)DataContext;

                this.OneWayBind(ViewModel, vm => vm.StepList, v => v.Steps.ItemsSource)
                    .DisposeWith(disposableRegistration);
            });

            #endregion

            var iconSize = (double)FindResource("IconSize"); // Works only if ResourceDictionary component has been initialized before
                                                             // (has been referenced in xaml and FindResource method has been called after InitializeComponent)
                                                             // Another interesting approach of referencing resource in code-behind: https://stackoverflow.com/a/24286059
            _navigationIcon = new PackIcon { Kind = Enum.Parse<PackIconKind>("ListStatus"), Width = iconSize, Height = iconSize };

            Steps.ItemContainerGenerator.StatusChanged += (sender, e) =>
                Steps.Dispatcher.Invoke(() => ItemContainerGenerator_StatusChanged(sender, e));
        }

        public object TabHeader => _navigationIcon;

        #region Non-essential

        private int _previouslyHighlightedItemIndex;

        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            var icg = (ItemContainerGenerator)sender;

            var totalCount = icg.Items.Count;

            for (int i = _previouslyHighlightedItemIndex; i < totalCount; i++)
            {
                var lbi = icg.ContainerFromIndex(i) as ListBoxItem;

                if (FindChild<Border>(lbi, "ItemBorder") is { } border)
                {
                    border.Background = new SolidColorBrush(Colors.Transparent);
                    border.Background.BeginAnimation(SolidColorBrush.ColorProperty, _newItemAnimation);

                    _previouslyHighlightedItemIndex++;
                }
            }

            _previouslyHighlightedItemIndex = Math.Min(totalCount, _previouslyHighlightedItemIndex);
        }

        private bool _autoscroll = true;

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // User scroll event : set or unset auto-scroll mode
            if (e.ExtentHeightChange == 0)
            {   // Content unchanged : user scroll event
                if (ScrollViewer.VerticalOffset == ScrollViewer.ScrollableHeight)
                {   // Scroll bar is in bottom
                    // Set auto-scroll mode
                    _autoscroll = true;
                }
                else
                {   // Scroll bar isn't in bottom
                    // Unset auto-scroll mode
                    _autoscroll = false;
                }
            }

            // Content scroll event : auto-scroll eventually
            if (_autoscroll && e.ExtentHeightChange != 0)
            {   // Content changed and auto-scroll mode set
                // Autoscroll
                ScrollViewer.ScrollToVerticalOffset(ScrollViewer.ExtentHeight);
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta / 10);
            e.Handled = true;
        }

        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName = "")
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        #endregion
    }
}
```

### Create an API service

UI-side API service is a class that inherits from gRPC class that is auto-generated on a project build by the gRPC tools. Its responsibility is to listen to clients and update the mutable model

- First, create a new .NET Core class library project and name it `ProjectWeekendPuzzles.<YourModule>.Api`
- Do not forget to set the target framework to `net5.0-windows`
- Reference the model project
- Create `Protos` and `Services` folders

:::caution
As I mentioned earlier, there is a problem with the generation of gRPC assets from .proto files in the WPF project; you can learn more about this known issue [here](https://docs.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-3.0#wpf-projects-unable-to-generate-grpc-c-assets-from-proto-files). The simplest workaround for it is to keep gRPC tools in a separate project. That is also a reason for having the separate model project just to break the circular dependency
:::

Proto files let for type-safe remoting that can be versioned, which is a huge advantage.

- Create a .proto file that will define IPC remote calls and messages. This very .proto file will be copied to and used as the contract and the scaffold source by a client project

```protobuf title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Api\Protos\step-list.proto"
syntax = "proto3";

option csharp_namespace = "ProjectWeekendPuzzles.StepList.Api";

package stepList;

service StepListUpdater {
  rpc AddStep (AddRequest) returns (AddReply);
  rpc ClearList (ClearRequest) returns (ClearReply);
}

message AddRequest {
  string name = 1;
  string result = 2;
  enum StepStatus {
		PASS = 0;
		FAIL = 1;
		ERROR = 2;
  }
  StepStatus status = 3;
}

message AddReply {
  bool success = 1;
}

message ClearRequest {

}

message ClearReply {
	bool success = 1;
}
```

- To the 'Services" folder, add a new class
- Name it `<YourModule>XXXService`
- Make it inherit from auto-generated gRPC service base class
- In ctor, ask for the `<YourModule>Model`
- Provide implementation by overriding `virtual`s

```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Api\Services\StepListUpdaterService.cs"
using Grpc.Core;
using ProjectWeekendPuzzles.StepList.Model;
using System;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.StepList.Api.Services
{
    public class StepListUpdaterService : StepListUpdater.StepListUpdaterBase
    {
        private readonly StepListModel _stepListModel;

        public StepListUpdaterService(StepListModel stepListModel)
        {
            _stepListModel = stepListModel;
        }

        public override Task<AddReply> AddStep(AddRequest request, ServerCallContext context)
        {
            var newStep = new Step(request.Name, request.Result, ConvertStatus(request.Status));
            _stepListModel.AddSteps(new[] { newStep });
            return Task.FromResult(new AddReply { Success = true });
        }

        public override Task<ClearReply> ClearList(ClearRequest request, ServerCallContext context)
        {
            _stepListModel.Clear();
            return Task.FromResult(new ClearReply { Success = true });
        }

        private static Step.StepStatus ConvertStatus(AddRequest.Types.StepStatus stepStatus)
            => stepStatus switch
            {
                AddRequest.Types.StepStatus.Pass => Step.StepStatus.Pass,
                AddRequest.Types.StepStatus.Fail => Step.StepStatus.Fail,
                AddRequest.Types.StepStatus.Error => Step.StepStatus.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(stepStatus), $"Cannot convert {nameof(AddRequest.Types.StepStatus)} because of the incompatible value.")
            };
    }
}
```

- In `<YourModule>Module` class, register `<YourModule>XXXService` through `ApiServiceCollection` (do not forget to reference `ProjectWeekendPuzzles.<YourModule>.Api` before)

```csharp {4-5,15,19} title="\src\modules\step-list\ProjectWeekendPuzzles.StepList\StepListModule.cs"
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.Core.ApiServer;
using ProjectWeekendPuzzles.StepList.Api.Services;
using ProjectWeekendPuzzles.StepList.Model;
using ProjectWeekendPuzzles.StepList.Views;

namespace ProjectWeekendPuzzles.StepList
{
    public class StepListModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public StepListModule(IRegionManager regionManager, ApiServiceCollection apiServiceCollection)
        {
            _regionManager = regionManager;

            apiServiceCollection.AddApiService<StepListUpdaterService>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion<StepListView>("main-content-region");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<StepListModel>();
        }
    }
}
```

### Create an API client

The last thing needed for our module to fully work is a client. As the UI and its clients are *almost* zero-coupled (*almost* because we still have a shared `.proto` file), we can use a different technology to build the client.

- Create a new .NET Framework library project that targets version 4.6.1
- Add following package references
    - Grpc.Tools
    - Google.Protobuf
    - Grpc.Core.Api
    - Grpc.Net.Client
    - Grpc.Net.Client.Web
    - System.Net.Http.WinHttpHandler
- Create `Protos` folder from the API project
- Next, unload the project and add the following snippet to it if not already present

```xml title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Client\ProjectWeekendPuzzles.StepList.Client.csproj"
...

<ItemGroup>
    <Protobuf Include="Protos\dashboard.proto" GrpcServices="Client" />
  </ItemGroup>

...
```
- Reload and build the project to generate gRPC assets
- Add App.config and put the port number in it
- Create the `<YourModule>XXXClient` class
```csharp title="\src\modules\step-list\ProjectWeekendPuzzles.StepList.Client\StepListUpdaterClient.cs"
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using ProjectWeekendPuzzles.StepList.Api;
using System;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.StepList.Client
{
    public class StepListUpdaterClient : IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly StepListUpdater.StepListUpdaterClient _client;

        public StepListUpdaterClient()
        {
            var portStr = ConfigurationSettings.AppSettings["port"] ?? "55331"; // fallback to default
            var port = int.Parse(portStr);

            _channel = GrpcChannel.ForAddress($"https://localhost:{port}", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new WinHttpHandler())
            });

            _client = new StepListUpdater.StepListUpdaterClient(_channel);
        }

        public async Task<AddReply> AddStepAsync(string name, string result, StepStatus status)
            => await _client
                .AddStepAsync(new AddRequest { Name = name, Result = result, Status = (AddRequest.Types.StepStatus) status })
                .ResponseAsync;

        public async Task<ClearReply> ClearAsync()
            => await _client
                .ClearListAsync(new ClearRequest())
                .ResponseAsync;

        public void Dispose() => _channel.Dispose();

        public enum StepStatus
        {
            Pass,
            Fail,
            Error
        }
    }
}
```

### Run the project

- Finally, rebuild the entire project and test your module through its client

![Step list](/img/getting-started/step_list.gif)