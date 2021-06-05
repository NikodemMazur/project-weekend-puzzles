---
sidebar_position: 5
---

# Reactive

It is essential for modules to listen to requests coming from their clients. One good fit for a module model is the Observer Pattern. Having the model injected, a view model's responsibility is to listen to changes in the model's state. Therefore, it is a good idea for the view model to utilize reactive extensions (System's Rx). If a user also decides on reactivity between his views and view models, ReactiveUI would be the perfect choice. As a result, a module would consist of a fully reactive MVVM trio whose code's conciseness is achieved through the declarative programming.

import ThemedImage from '@theme/ThemedImage';
import useBaseUrl from '@docusaurus/useBaseUrl';

<ThemedImage
  align="left"
  width="750"
  alt="Reactive"
  sources={{
    light: useBaseUrl('/img/reactive_light.svg'),
    dark: useBaseUrl('/img/reactive_dark.svg'),
  }} />