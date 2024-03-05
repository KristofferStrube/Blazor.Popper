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
        if (jSRuntime is IJSInProcessRuntime)
        {
            IJSInProcessObjectReference popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
            IJSObjectReference jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options);
#pragma warning disable CS0618 // Type or member is obsolete
            return new(jSInstance, popperWrapper);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {
            IJSObjectReference popperWrapper = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
            IJSObjectReference jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopperAsync", reference, popper, options);
            return new(jSInstance, popperWrapper);
        }
    }

    public async Task<Instance> CreatePopperAsync(VirtualElement reference, ElementReference popper, Options options)
    {
        if (jSRuntime is IJSInProcessRuntime)
        {
            IJSInProcessObjectReference popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
            IJSObjectReference jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options);
#pragma warning disable CS0618 // Type or member is obsolete
            return new(jSInstance, popperWrapper);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {
            IJSObjectReference popperWrapper = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
            IJSObjectReference jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopperAsync", reference, popper, options);
            return new(jSInstance, popperWrapper);
        }
    }
}
