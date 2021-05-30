---
sidebar_position: 5
---

# To do list

- Add checking if injected views meet the contract (`IHeadered` etc)
- Add region adapter behavior that disposes view and view model instances upon removing
- Create `RegionManager` extension methods to attach pluggable views in a type-safe manner (hiding shell's region names)
- Create `CompositeModuleCatalog` and `NugetConfigurationModuleCatalog`
- Solve scoped region managers problem in Navigation (Pluralsight)
- `Microsoft.Extensions.Logging` loggers registered in Wpf application should be accessible in the Api server
- All api endpoints should be mapped on the application initialization - that's why modules should ALWAYS be loaded on startup (`startupLoaded` option should be hidden from developers)