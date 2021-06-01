---
sidebar_position: 2
---

# Tech independence

The **model's technology independence** has been attained with *gRPC Web Server*. The server hosts *gRPC services* that listen to modules' *gRPC clients*. Every *gRPC service* is coupled to only one *Prism's* module. That way, modules are controlled separately by a client that they provide. At this point, one should notice an important requirement that all modules have to be initialized prior to running the *gRPC Server*. In turn, the requirement suggests that a plugin authorization should be as late as in the *Prism's* navigation mechanism

:::warning TODO
- Add graph that shows the UI and Test Runner that communicate with each other through IPC
:::