using MaterialDesignThemes.Wpf;
using ProjectWeekendPuzzles.Core.ViewContract;
using ProjectWeekendPuzzles.Dashboard.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System;

namespace ProjectWeekendPuzzles.Dashboard.Views
{
    /// <summary>
    /// Helper base class to use ReactiveUserControl.
    /// (WPF designer doesn't support generic types)
    /// </summary>
    public class DashboardViewBase : ReactiveUserControl<DashboardViewModel> { }

    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : DashboardViewBase, IHeadered
    {
        private readonly PackIcon _navigationIcon;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public DashboardView()
        {
            InitializeComponent();

            #region ReactiveUI stuff

            this.WhenActivated(disposableRegistration =>
            {
                // At this moment, Prism's ViewModelLocator assigns a view model to DataContext.
                ViewModel = (DashboardViewModel)DataContext;

                this.OneWayBind(ViewModel, vm => vm.PassCount, v => v.PassCountRun.Text, prop => prop.ToString())
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel, vm => vm.FailCount, v => v.FailCountRun.Text, prop => prop.ToString())
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel, vm => vm.ErrorCount, v => v.ErrorCountRun.Text, prop => prop.ToString())
                    .DisposeWith(disposableRegistration);
            });

            #endregion

            var iconSize = (double)FindResource("IconSize"); // Works only if ResourceDictionary component has been initialized before
                                                             // (i.e. has been referenced in xaml and FindResource method has been called after InitializeComponent)
                                                             // Another interesting approach of referencing resource in code-behind: https://stackoverflow.com/a/24286059
            _navigationIcon = new PackIcon { Kind = Enum.Parse<PackIconKind>("Speedometer"), Width = iconSize, Height = iconSize };
        }

        public object TabHeader => _navigationIcon;
    }
}
