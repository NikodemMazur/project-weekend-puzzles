---
sidebar_position: 1
---

# Nomenclature

- **Module** - A collection of functionality and resources that are plugged into the main application. Usually, a package developed by a user
- **User** - One who extends the application by providing modules
- **Developer** - Application and core code designer and maintainer
- **Application** - DLL with the shell window and main mechanisms, such as API server and authorization
- **Core** - DLL with classes and resources that are shared among the application and modules
- **Shell** - Main window that contains all the modules
- **Server service** - A middleware that listen to clients' requests. In this project, the term applies to gRPC server services
- **Client service** - Automatically generated class that sends requests to server services. As already mentioned, it applies to gRPC client services