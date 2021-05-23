---
sidebar_position: 1
---

# Release 1.0.0

What's been achieved in the first version:

- **Prism** framework has been combined with **ReactiveUI**
- Modules are loaded as `IModule`'s. A list of modules to attach is in the XML configuration file.
- View models listen to a model through the Observer Pattern (`System.Reactive`)
- **ASP.NET Core** server with **gRPC** middleware accepts pluggable **gRPC** server services that are provided by modules
- Both **gRPC** services and view models use reactive (`IObservable<T>`) models
- Cool look achieved in seconds with **Material Design**
- **Material Design's** theme introduced the consistency throughout the modules' views

What's expected to be done in the next release:

- Plugin authorization with the use of **Prism's** region behaviors