[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)
[![GitHub issues](https://img.shields.io/github/issues/KristofferStrube/Popperize)](https://github.com/KristofferStrube/Popperize/issues)
[![GitHub forks](https://img.shields.io/github/forks/KristofferStrube/Popperize)](https://github.com/KristofferStrube/Popperize/network/members)
[![GitHub stars](https://img.shields.io/github/stars/KristofferStrube/Popperize)](https://github.com/KristofferStrube/Popperize/stargazers)
[![NuGet Downloads (official NuGet)](https://img.shields.io/nuget/dt/KristofferStrube.Blazor.Popper?label=NuGet%20Downloads)](https://www.nuget.org/packages/KristofferStrube.Blazor.Popper/)  

# Introduction
A Blazor wrapper for the JavaScript library Popper.js

# Demo

The sample project can be demoed at [https://kristofferstrube.github.io/Blazor.Popper/](https://kristofferstrube.github.io/Blazor.Popper/)

# Getting Started
## Prerequisites
You need to install .NET 6.0 or newer to use the library.

[Download .NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

## Installation
You can install the package via Nuget with the Package Manager in your IDE or alternatively using the command line:
```bash
dotnet add package KristofferStrube.Blazor.Popper
```

# Usage
The package can be used in Blazor WebAssembly projects.
## Assets
You first need to reference `popper.js` since this is only a wrapper. You can do this using your favorite JS package manager (e.g. `NPM` or `Library Manager`) or just add the following to the body of your `index.html` file after the point where you reference `_framework/blazor.webassembly.js`.
```html
<script src="https://unpkg.com/@popperjs/core@2"></script>
```
## Import
You also need to reference the package in order to use it in your pages. This can be done in `_Import.razor` by adding the following.
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

    builder.Services.AddScoped<Popper>();

    await builder.Build().RunAsync();
}
```
## Inject in page
In any page that need a popper you can then inject Popper by adding the following to the top of the razor file.
```
@inject Popper Popper;
```
Then you can use `Popper` to create a popper instance between two `ElementReference`'s like so:
```razor
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

# Related articles
This repository was build on top of the work done in the following series of articles:

- [Wrapping JavaScript libraries in Blazor WebAssembly/WASM](https://blog.elmah.io/wrapping-javascript-libraries-in-blazor-webassembly-wasm/)
- [Call anonymous C# functions from JS in Blazor WASM](https://blog.elmah.io/call-anonymous-c-functions-from-js-in-blazor-wasm/)
- [Using JS Object References in Blazor WASM to wrap JS libraries](https://blog.elmah.io/using-js-object-references-in-blazor-wasm-to-wrap-js-libraries/)
- [Blazor WASM 404 error and fix for GitHub Pages](https://blog.elmah.io/blazor-wasm-404-error-and-fix-for-github-pages/)
- [How to fix Blazor WASM base path problems](https://blog.elmah.io/how-to-fix-blazor-wasm-base-path-problems/)
