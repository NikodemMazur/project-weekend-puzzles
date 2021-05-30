---
sidebar_position: 1
---

# Modularity

Modularity has been achieved with *Prism Library*. The library, which actually is an open-source framework, is used explicitly and is not hidden behind any interfaces nor abstracted in any other way. PWP allows a developer to extend its content through creating loosely coupled plugins (aka *Prism's* modules) that meet a contract defined and contained in the PWP's core dll. This way, the second *SOLID* principle is strongly enforced. In addition to modules, PWP also utilizes other *Prism's* features such as MVVM helpers, Navigation and Dependency Injection. *Prism* is an extensible framework whose user can easily inject a custom implementation into it - for instance, to have child tabs inside parent tabs, a developer needs to overwrite (through DI registering) the `ScopedRegionNavigationContentLoader` class. *Prism* can be called the "first-framework citizen" as the most components of PWP are built on the top of it - therefore it is critical to PWP's developers and users to know every *Prism's* mechanism in detail to be able to freely tailor them for the application needs.