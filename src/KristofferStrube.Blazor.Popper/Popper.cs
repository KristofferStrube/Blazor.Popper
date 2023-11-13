using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper;

public class Popper
{
    private readonly IJSRuntime jSRuntime;
    private const string PopperWrapperContent = "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js";
    public Popper(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task<Instance> CreatePopperAsync(ElementReference reference, ElementReference popper, Options options)
    {
        return await CreatePopperAsync<ElementReference>(reference, popper, options);
    }


    public async Task<Instance> CreatePopperAsync(VirtualElement reference, ElementReference popper, Options options)
    {
        return await CreatePopperAsync<VirtualElement>(reference, popper, options);
    }

    private async Task<Instance> CreatePopperAsync<T>(T reference, ElementReference popper, Options options)
    {
        IJSObjectReference popperWrapper;
        try
        {
            popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", PopperWrapperContent);
        }
        catch (JSException)
        {
            popperWrapper = await jSRuntime.InvokeAsync<IJSObjectReference>("import", PopperWrapperContent);
        }
        var jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options);
        return new Instance(jSInstance, popperWrapper);
    }
}
