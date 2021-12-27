using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper;

public class Popper
{
    private readonly IJSRuntime jSRuntime;

    public Popper(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task<Instance> CreatePopperAsync(ElementReference reference, ElementReference popper, Options options)
    {
        var popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
        var jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options);
        return new(jSInstance, popperWrapper);
    }

    public async Task<Instance> CreatePopperAsync(VirtualElement reference, ElementReference popper, Options options)
    {
        var popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
        var jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options);
        return new(jSInstance, popperWrapper);
    }
}
