using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper;

/// <summary>
/// A native C# wrapper for the Popper.js library
/// </summary>
public class Popper
{
    /// <summary>
    /// The Popper JavaScript runtime
    /// </summary>
    private readonly IJSRuntime jSRuntime;
    /// <summary>
    /// The Popper.js wrapper path
    /// </summary>
    private const string PopperWrapperContent = "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js";
    /// <summary>
    /// Initializes a new instance of the <see cref="Popper"/> class.
    /// </summary>
    /// <param name="jSRuntime">The Popper JavaScript runtime.</param>
    public Popper(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    /// <summary>
    /// Creates the Popper asynchronously.
    /// </summary>
    /// <param name="reference">The reference element (the container or context in which the Popper effect is shown).</param>
    /// <param name="popper">The Popper effect to show.</param>
    /// <param name="options">The Popper options.</param>
    /// <returns></returns>
    public async Task<Instance> CreatePopperAsync(ElementReference reference, ElementReference popper, Options options)
    {
        return await CreatePopperAsync<ElementReference>(reference, popper, options);
    }


    /// <summary>
    /// Creates the Popper effect asynchronously.
    /// </summary>
    /// <param name="reference">The reference element (the container or context in which the Popper effect is shown).</param>
    /// <param name="popper">The Popper effect to show.</param>
    /// <param name="options">The Popper options.</param>
    /// <returns></returns>
    public async Task<Instance> CreatePopperAsync(VirtualElement reference, ElementReference popper, Options options)
    {
        return await CreatePopperAsync<VirtualElement>(reference, popper, options);
    }

    /// <summary>
    /// Creates the Popper effect asynchronously.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reference">The reference element (the container or context in which the Popper effect is shown).</param>
    /// <param name="popper">The Popper effect to show.</param>
    /// <param name="options">The Popper options.</param>
    /// <returns></returns>
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
