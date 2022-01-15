# Blazor Starter Application

This template contains an example .NET 6 [Blazor WebAssembly](https://docs.microsoft.com/aspnet/core/blazor/?view=aspnetcore-6.0#blazor-webassembly) client application, a .NET 6 C# [Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-overview), and a C# class library with shared code.

## Getting Started

1. Create a repository from the [GitHub template](https://docs.github.com/en/enterprise/2.22/user/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template) and then clone it locally to your machine.

1. In the **Api** folder, copy `local.settings.example.json` to `local.settings.json`

1. Continue using either Visual Studio or Visual Studio Code.

### Visual Studio 2022

Once you clone the project, open the solution in [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) and follow these steps:

1. Right-click on the solution and select **Set Startup Projects...**.

1. Select **Multiple startup projects** and set the following actions for each project:
    - *Api* - **Start**
    - *ApiIsolated* - None
    - *Client* - **Start**
    - *Shared* - None

1. Press **F5** to launch both the client application and the Functions API app.

### Visual Studio Code with Azure Static Web Apps CLI

1. Install the [Azure Static Web Apps CLI](https://www.npmjs.com/package/@azure/static-web-apps-cli) and [Azure Functions Core Tools CLI](https://www.npmjs.com/package/azure-functions-core-tools).

1. Open the folder in Visual Studio Code.

1. In the VS Code terminal, run the following command to start the Static Web Apps CLI, along with the Blazor WebAssembly client application and the Functions API app:

    ```bash
    swa start http://localhost:5000 --run "dotnet run --project Client/Client.csproj" --api-location Api
    ```

    The Static Web Apps CLI (`swa`) first starts the Blazor WebAssembly client application and connects to it at port 5000, and then starts the Functions API app.

1. Open a browser and navigate to the Static Web Apps CLI's address at `http://localhost:4280`. You'll be able to access both the client application and the Functions API app in this single address. When you navigate to the "Fetch Data" page, you'll see the data returned by the Functions API app.

1. Enter Ctrl-C to stop the Static Web Apps CLI.

## Template Structure

- **Client**: The Blazor WebAssembly sample application
- **Api**: A C# Azure Functions API, which the Blazor application will call
- **Shared**: A C# class library with a shared data model between the Blazor and Functions application
- **ApiIsolated**: A C# Azure Functions API using the .NET isolated execution model, which the Blazor application will call. This version can be used instead of the in-process function app in `Api`.

## Deploy to Azure Static Web Apps

This application can be deployed to [Azure Static Web Apps](https://docs.microsoft.com/azure/static-web-apps), to learn how, check out [our quickstart guide](https://aka.ms/blazor-swa/quickstart).

Several Errors:
- Missing local.setting.json causes language not found!
- Multiple dotnet runtime and sdks cause problems: _GenerateFunctionsExtensionsMetadataPostBuild
    - https://github.com/dotnet/cli-lab/releases
    - https://github.com/Azure/azure-functions-core-tools/issues/2876
- Ambigius Match Found: https://adamstorr.azurewebsites.net/blog/ambiguous-match-found-in-azure-functions-project
- func start to start locally
- swa start http://localhost:5000 --run "dotnet run --project Client/Client.csproj" --api-location Api
- Rounting: https://www.c-sharpcorner.com/article/routing-in-azure-function/
- VS Code got into a problem where it could not resolve any application mode.....close VS Code and restart....make sure you close VS Code completely (all instances).
- I opted to only use the isolated mode.
- Configuration goes in local.setting.json ....but when in Azure, they must be added to application configuration.