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
- Add folder to directory structure (MoreHuman.Software.Chat.Ui)
- Add IIS application for site
- Downloaded and copied the geckodriver
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
  - Add ids to time and date
    

## Thoughts on Breaking this Monolith

- Application variable is used as backing store for both pages
- Move the Application calls to a db
- Microservice for storage
- Microservice for main page
- Microservice for message
- Microservice for API