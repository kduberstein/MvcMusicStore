# Mvc Music Store
This solution is my interpretation of the popular ASP.NET [Mvc Music Store](http://www.asp.net/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-1) tutorial. It is not meant to be a complete solution, rather it is meant to demonstrate how to properly structure a domain-driven solution design.

[Download the solution](https://github.com/kduberstein/MvcMusicStore/archive/master.zip).

### How to run

Unzip the solution file, open in Visual Studio 2013 (or later), and build the solution. Ensure that the Visual Studio [NuGet Package Manager](https://visualstudiogallery.msdn.microsoft.com/4ec1526c-4a8c-4a84-b702-b21a8f5293ca) extension is installed. All NuGet packages will be restored during the build. Set MusicStore.WebUI as the startup project and run.

The database is located in the App_Data folder. If the site is unable to connect to the database, verify the location of the database and ensure that the connection string in Web.config is correct.

#### Infrastructure
The solution layout is inspired by Eric Evan's popular Domain Driven Design book, primarily relying on SOLID principles to separate concerns. It uses Castle Windsor IoC container and relies heavily on dependency injection. In addition, the program uses NHibernate to simplify data access, a service layer, and a message/response pattern to allow for future web services. These design decisions make the program highly scalable, easily unit-testable, and helps future-proof the program in the hope of lowering future development costs.

Parts of this sample program are ommitted, or kept intentionally simple, to make it easier to understand exactly what the code is doing. The website design utilizes Bootstrap to make it viewable on any device size, eliminating the need to develop multiple designs to fit various devices. The site also uses a custom IPrincipal which provides a more flexible authentication solution versus inheriting from Microsoft's MembershipProvider.
