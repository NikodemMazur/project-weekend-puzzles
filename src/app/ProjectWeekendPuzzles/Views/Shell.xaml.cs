using MaterialDesignThemes.Wpf;
using ProjectWeekendPuzzles.Core.MvvmHelpers;
using System.Windows;
using System.Windows.Input;

namespace ProjectWeekendPuzzles.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IClosable
    {
        public Shell()
        {
            InitializeComponent();

            PaletteHelper paletteHelper = new();
            ITheme theme = paletteHelper.GetTheme();
            DarkModeToggleButton.IsChecked = theme.GetBaseTheme() == BaseTheme.Dark;

            if (paletteHelper.GetThemeManager() is { } themeManager)
                themeManager.ThemeChanged += (_, e) => DarkModeToggleButton.IsChecked = e.NewTheme?.GetBaseTheme() == BaseTheme.Dark;
        }

        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
            => ModifyTheme(DarkModeToggleButton.IsChecked == true);

        private static void ModifyTheme(bool isDarkTheme)
        {
            PaletteHelper paletteHelper = new();
            ITheme theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

        private void title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        void IClosable.Close() => Close();

        public object CustomHeader { get; } = new PackIcon { Kind = PackIconKind.DinosaurPixel, Width = 32, Height = 32 };
    }
}
