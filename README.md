# Breaking the Monolith Code Notes

This document will eventually become the documentation root of this project.  For now it's the live notes of my work on this project.

## Step Taken So Far

- Install Visual Studio Enterprise
- Install Resharper
- Install Selenium IDE
- Create Empty Solution
- Create an xUnit Test Project (MoreHuman.Software.Tests.Ui)
- Click through When a new user joins
- Export C# xUnit
- Add Nuget Package for Selenium WebDriver
- Add Nuget Package for Selenium WebDriver support
- Note that we have no way to identify the clock and date
- Add Project Empty ASP.NET Core (MoreHuman.Software.Chat.Ui)
- Add Nuget Packages
  - Microsoft.AspNetCore.Http
  - Microsoft.AspNetCore.Hosting.Abstractions
  - Microsoft.AspNetCore.Routing.Abstractions
- Read [Migrate HTTP handlers and modules to ASP.NET Core middleware](https://docs.microsoft.com/en-us/aspnet/core/migration/http-modules?view=aspnetcore-3.0) - somewhat helpful
- Read [IIS modules with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/modules?view=aspnetcore-3.0) - Very Helful
- Read [Static files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-3.0) - Very Helpful
- Modify Startup.cs to use static files
```
```
- Create a new application in IIS with .NET Framework

## Steps to take

- Unit tests for the UI
  - We can cover most every function in a small application
  - We can't cover this in large applications, test as you go
    - [See Working Effectively with Legacy Code](https://www.amazon.com/Working-Effectively-Legacy-Michael-Feathers/dp/0131177052)

### Test 1: When a new uer joins

- Double click on each element
- Changes
  - Label the clock and date
  - We can use some css selectors to select each element
    - `css=tr:nth-child(3) > td:nth-child(2)`
    - `css=tr:nth-child(3) > td:nth-child(3)`
    - `css=tr:nth-child(3) > td:nth-child(2)`
    

## Thoughts on Breaking this Monolith

- Application variable is used as backing store for both pages
- Move the Application calls to a db
- Microservice for storage
- Microservice for main page
- Microservice for message
- Microservice for API