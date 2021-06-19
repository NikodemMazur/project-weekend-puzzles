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
