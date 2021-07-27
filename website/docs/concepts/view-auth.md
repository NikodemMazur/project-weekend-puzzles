---
sidebar_position: 3
---

# View authorization

The application (the one with the shell) contains `Security.Authentication` and `Security.Authorization` namespaces that introduce the role-based authorization into `Prism`'s region mechanism. If the user does not have a required role to see a view, the `ReloadRegionViewsRegionBehavior` class, that has dependency to `Security.Authentication`, removes the view. When a user is switched and the new one meets role requirements, the view is added back to the region. Although, authorized views are not visible immediately after the application startup (because `User.Anonymous` does not have any roles), they all are loaded into the application memory along with their modules as early as when the application starts.

![Authorization](/img/authentication.gif)

All the user needs to do when restricting the access to a view is to annotate the view class with the convenient `AuthorizeRoleAttribute` attribute.

```csharp {7} title="\src\modules\module-info\ProjectWeekendPuzzles.ModuleInfo\Views\ModuleInfoView.xaml.cs"
// ...
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
// ...
```