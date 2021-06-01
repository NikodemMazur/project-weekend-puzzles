---
sidebar_position: 2
---

# Tech stack

Project Weekend Puzzles has been built with several technologies. Some of them are transparent to users, such as ASP.NET Core - some are explicitly being used in everyday modules' development, that is, they are not abstracted or hidden from a user.

## [Prism Library](https://prismlibrary.com/)

- ViewModelLocator
- DI (DryIoc)
- Navigation
- Regions
- Modules
- Dialog Services

## [ReactiveUI (Recommended)](https://www.reactiveui.net/)

- Data Binding (type-safe)
- Commands
- `WhenAny`

## [.NET 5 WPF](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/?view=netdesktop-5.0)

- Every dll is a WPF project (even Core)
- Easy port to Uno Platform in a case of need for multi-platform in the future

## [ASP.NET Core (Transparent)](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0)

- Module gRPC services are injected into the pipeline at runtime

## [gRPC](https://grpc.io/)

- gRPC-Web (for maximum interoperability - even with .NET Framework clients)
- gRPC Tools

## [Material Design in XAML (Recommended)](http://materialdesigninxaml.net/)

- Theme (inherited by modules from Shell)
- Controls
- Icons