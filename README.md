# About
AzRBlog is personal blog project for blogging. which is develop top of .NET 4.7.2, using ASP.NET MVC5,WEB API v2, EF 6.2, autofact, MSTest, Bootstrap 4, jQuery, underscore.js, chart.js.In this project we using Generic Repository Pattern concept.

# Technology

Technology are uses :- 

- .NET 4.7.2
- ASP.NET MVC5
- WEB API v2
- Autofact
- MSTest
- Bootstrap 4
- jQuery
- underscore.js
- chart.js
- SQL Server 2016


## Prerequisites
You will need any edition of Visual Studio 2017 and any edition of SQL Server (2016) to run this project.

## Getting Started
1. Clone or Download the project. Run the ```AzRBlog.sln``` solution file in your Visual Studio and build.
2. Right click on ``AzRBlog.Web`` and select **Set StartUp Project** for amke ``AzRBlog.Web`` as startup project.
3. Go ``Web.Config`` and Change your Connection String in ``ConnectionString`` section.
4. Go **Tools> nuget package manager> package manager console** in Visula studio and open on ``package manager console``.
5. Select ``AzRBlog.Entities``form dropdown and run ``update-database`` command.
6. Finaly Run the application.

