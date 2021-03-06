---
sidebar_position: 0
---

# What is it?

![Remote control](/img/remote_control.gif)

Project Weekend Puzzles (PWP) is a proof of concept of a desktop UI whose three primary features are **modularity**, **a model's technology independence** and **module authorization with RBAC**.

import ThemedImage from '@theme/ThemedImage';
import useBaseUrl from '@docusaurus/useBaseUrl';

<ThemedImage
  align="left"
  width="550"
  alt="Layers"
  sources={{
    light: useBaseUrl('/img/layers_light.svg'),
    dark: useBaseUrl('/img/layers_dark.svg'),
  }} />

The UI can be extended through modules that provide the implementation for 5 layers: Views, View Models, Model, API Service and API Client.

The last two of these handle IPC between the UI and module clients in a server-client relationship. As the IPC implementation of choice is gRPC Web Server, both client- and server-side streaming are available.

Server-client service pairs come with modules. A client can control only a module with which it has been provided.

The business logic of the UI single module's model comes down only to reacting to client's requests. In the future, if one resigned from having IPC, the model layer could be replaced by an application that used to control the UI through a client.

Views injected by modules are activated or deactivated with respect to roles of a currently logged-in user.

A possible scenario for following such an architecture is a need for UI whose content changes rapidly due to either slightly different or completely new requirements imposed by a customer. At the same time, the UI needs to be controlled by several various back-ends having similar business logic though built with different technology.
