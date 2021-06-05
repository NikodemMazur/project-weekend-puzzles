---
sidebar_position: 2
---

# Building

The fastest way to understand what this project is about is to run it. The following steps will instruct you how to build the main application along with the off-the-shelf modules.

## Build the app and referenced modules

To run the application with all modules loaded, one should build the *app* solution first. The solution output are *ProjectWeekendPuzzles.exe* and *ProjectWeekendPuzzles.Core.dll*; the latter is needed prior to building modules since it is the main dependency of the entire project. At this point, the output executable *ProjectWeekendPuzzles.exe* would be runnable if *ProjectWeekendPuzzles.dll.config* had not told it to search for *dashboard* and *module-info* modules. Therefore, before running the executable, one needs to visit the module solutions and build them. Once it is done, the executable should run without any errors.

## Control modules through LINQPad 5

The Project Weekend Puzzles is up and running. The *dashboard* module can be controlled through its client. Run `<your-repo-folder>\project-weekend-puzzles\tests\modules\dashboard\TestQuery.linq` and see the *dashboard* module view updated to what you send as a request.
