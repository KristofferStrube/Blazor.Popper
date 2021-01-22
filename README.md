# Popperize
A Blazor wrapper for the JavaScript library Popper.js

# Getting Started
## Prerequisites
You need to install .NET 5.0 or newer to use the library.

[Download .NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

## Installation
You can install the package via Nuget with the Package Manager in your IDE or alternatively using the command line:
```bash
dotnet add package KristofferStrube.Blazor.Popper
```

# Usage
The package can be used in Blazor projects both WebAssembly and Server-side.
## Assets
You first need to reference `popper.js` since this is only a wrapper. You can do this using you favorite JS package manager (e.g. `NPM` or `Library Manager`) or just add the following to the body of your `index.html` file for WebAssembly or `_Host.cshtml` for Blazor Server-side after the point where you reference `_framework/blazor.webassembly.js`.
```html
<script src="https://unpkg.com/@popperjs/core@2"></script>
```
## Import
You also need to reference the package in order to use it in you packages. This can be done in `_Import.razor` by adding the following.
```csharp
@using KristofferStrube.Blazor.Popper
```
## Add to service collection
An easy way to make Popper available in all your pages is by registering it in the `IServiceCollection` so that it can be dependency injected in the pages that need it. This is done in `Program.cs` by adding the following before you build the service collection.
```csharp
public static async Task Main(string[] args)
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");

    // Other services are added.

    builder.Services.AddScoped(sp => new Popper(sp.GetService<IJSRuntime>()));

    await builder.Build().RunAsync();
}
```
## Inject in page
In any page that need a popper you can then inject Popper by adding the following to the top of the razor file.
```
@inject Popper Popper;
```
The you can use the popper to create a popper instance between to `ElementReference`'s like so:
```csharp
<span @ref=reference>reference</span>
<span @ref=popper>popper</span>

@code {
    protected ElementReference reference;
    protected ElementReference popper;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Popper.CreatePopperAsync(reference, popper, new());
    }
}
```