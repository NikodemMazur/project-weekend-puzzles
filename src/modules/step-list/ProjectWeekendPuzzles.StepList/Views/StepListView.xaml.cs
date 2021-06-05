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
