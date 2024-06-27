# Dotnet WakaTimeApi

! Currently in development !

> Version 0.6.0

This is a .NET 8 library for the WakaTime API. 
It is a simple wrapper around the [WakaTime](https://wakatime.com/) API, which allows you to easily interact with the API.

## Usage
To use the library, you'll need to get an API key from the [WakaTime website](https://wakatime.com/settings/api-key).
### Add the WakaTimeApi package 
``dotnet add package WakaTimeApi --version 0.6.0``
```xml
<!--.csproj-->
<PackageReference Include="WakaTimeApi" Version="0.6.0" />
```

### Using Service Provider

```csharp
using WakaTimeApi;

Builder.Services.AddWakaTimeApi("!!Your API Key!!");

// Your scoped service
public ctor(WakaTimeApiClient wakaTimeApi)
{
    // Use the wakaTimeApi
    var temp = wakaTimeApi.GetStatsResponse();
}
```

### Using the client directly

```csharp
using WakaTimeApi;

WakaTimeApiClient api = WakaTimeServiceProvider.GetWakaTimeApiClient("!!Your API Key!!");
var projects = await api.GetProjects();
```



## Extra Information

- This library is still in development, so there are some features that are not yet implemented.
- This library uses Dotnet 8.0, so you'll need to have the Dotnet 8.0 SDK installed to use it.
- This library uses a custom ``JsonSerializerContext`` so it is AOT compatible.

## Contributing

If you would like to contribute to this project, please feel free to fork the repository and submit a pull request.
To run the tests or the sample AOT application you'll need to put your 
WakaTime API key in your local user environment variables 
as `WakaTimeToken` (at least for now till 
    I have set up everything for it to work separately). 

