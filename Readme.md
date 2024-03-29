﻿# Movie REST API Project 

## Attribute Based Routing
On controllers -> RouteAttribute
[Route("api/Products")] or [Route("api/[controller]")]
On routes -> Http[Verb]Attribute
[HttpGet("getSingleProduct")] or [HttpGet("[action]")]

The Http[Verb]Attribute and RouteAttribute attributes can be assigned multiple times to define multiple routes, and are hierarchical, which means that they support route inheritance. This means that if you configured a route on your controller, the routes you define on the methods will extend it.
If the Http[Verb]Attribute that you set on a method contains a string that begins with /, then it won't be combined with the route defined in the controller, and will instead define a route of its own.

Attribute-based routing supports a few predefined tokens that are placed in square brackets ([ and ]), and will be replaced at runtime with their corresponding value:
[controller]: This will be replaced with the controller name.
[action]: This will be replaced with the method name.
[area]: If your application supports areas, this will be replaced with the area in which the controller resides.
Tokens within curly braces ({}) define route parameters that will be bound to the method parameters if the route is matched.
Default values are defined by placing an equals sign next to the route parameter. 
Eg: [HttpGet("searchcategory/{category}/{subcategory=all}/")]


## lauchsetting
launchSettings.json is used for development-time configuration, specifying how the application should run during development and debugging.

## appsetting
The settings in appsettings.json can be bound to strongly-typed classes in your application using the Options pattern.
If there are settings that your application needs to use, please store them in appsettings.json.

In launchSettings.json file, we have a key called ASPNETCORE_ENVIRONMENT. The value defined against this key tells about the environment of ASP.Net Core project.

If the value is Development, then key available in appsettings.Development.json file will be loaded and if the value is Production then key from appsettings.Production.json file will be loaded.	 
https://www.sharepointcafe.net/2021/04/appsettings-in-dotnet-core.html

There are two ways to access or use appsettings.development.json file value:
1. By the use of IOptions
https://www.codeproject.com/Articles/5339413/Adding-Configuration-to-NET-6-Projects-using-the-I
2. By the use of IConfigurations
Just in the file you want to use configuration just inject IConfiguration through DI.The IConfiguration interface is automatically registered with the dependency injection container, and it's available for injection into controllers, services, or other components.

   private readonly IConfiguration _configuration;
   public WeatherForecastController(IConfiguration configuration)
    {
            _configuration = configuration;
     }
    var mySettingskey1 = _configuration["MySettings:Key1"];


## Creating Database with Migrations
Add-Migration Initial
Update-Database