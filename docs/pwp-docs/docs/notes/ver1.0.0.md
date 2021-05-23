---
sidebar_position: 1
---

# Release 1.0.0

That's what has been achieved in the first version:

- **Prism** framework has been combined with **ReactiveUI**
- Views are injected as `IModule`'s
- View models listen to a model via the Observer Pattern (`System.Reactive`)
- **ASP.NET Core** server with **gRPC** middleware accepts pluggable **gRPC** server services provided by modules
- **gRPC** endpoint services use `IObservable<T>` models
- Cool look achieved in seconds with **Material Design**
- **Material Design's** theme introduced the consistency throughout the modules' views

What's expected to be done in the next release:

- Plugin authorization with use of **Prism's** region behaviors