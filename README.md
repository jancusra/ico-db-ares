# .NET Core 2.0 web project architecture

Oriented to web server project architecture presentation:

* Core - entities from database - used net core entity framework first code
* Services - loading data from database / online api
* Web - services use dependency injection, models from services mapped by AutoMapper, some very simple single page front-end (used jQuery)


## Testing functionality

1. restore icos.bak file to SQL database (created on MSSQL 2014)
2. probably you will need [.NET Core 2.0 development tools](https://www.microsoft.com/net/download/core)
3. build on VS (created on VS 2017)
