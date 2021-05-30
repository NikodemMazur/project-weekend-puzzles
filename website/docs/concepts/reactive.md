---
sidebar_position: 5
---

# Reactive

It is essential for modules to listen to requests coming from their clients. A one good fit for a module model is the Observer Pattern. Having the model injected, a view model's responsibility is to listen to the model's state changes - therefore, it is good idea for the view model to utilize reactive extensions (System's Rx). If a user also goes for reactivity between his views and view models, ReactiveUI would be a brilliant choice. As a result, a module would consist of fully reactive MVVM trio whose code's conciseness is achieved through the declarative programming.