## Clean Code Architecture

#### This sample application uses MediatR + CQRS Pattern

_Install the following:_

-Web API, Core
```
Install-Package MediatR
```
-Core
```
Install-Package MediatR.Extensions.Microsoft.DependencyInjection
```
```
Install-Package Mapster -Version 7.3.0
```
-Migration using Package Manager Console 

_Note: (Make sure in Package Manager Console the default project is App.Infrastructure)_

```
cd App.Infrastructure
```
```
Add-Migration InitialCreate
```
```
Update-Database
```
