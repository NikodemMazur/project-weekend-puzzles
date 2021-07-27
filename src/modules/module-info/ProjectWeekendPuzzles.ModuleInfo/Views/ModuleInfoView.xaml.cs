using MaterialDesignThemes.Wpf;
using ProjectWeekendPuzzles.Core.Security.Authorization;
using ProjectWeekendPuzzles.Core.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectWeekendPuzzles.ModuleInfo.Views
{
    /// <summary>
    /// Interaction logic for ModuleInfoView.xaml
    /// </summary>
    [AuthorizeRole("developer")]
    public partial class ModuleInfoView : UserControl, IHeadered
    {
        private readonly PackIcon _navigationIcon;

        public ModuleInfoView()
        {
            InitializeComponent();

            var iconSize = (double)FindResource("IconSize"); // Works only if ResourceDictionary component has been initialized before
                                                             // (i.e. has been referenced in xaml and FindResource method has been called after InitializeComponent)
                                                             // Another interesting approach of referencing resource in code-behind: https://stackoverflow.com/a/24286059
            _navigationIcon = new PackIcon { Kind = Enum.Parse<PackIconKind>("InfoOutline"), Width = iconSize, Height = iconSize };
        }

        public object TabHeader => _navigationIcon;
    }
}
