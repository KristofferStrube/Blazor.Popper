using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper;

public class Instance
{
    private readonly IJSObjectReference jSInstance;
    private readonly IJSObjectReference popperWrapper;

    [Obsolete("Only supported in Blazor WASM. ")]
    private readonly IJSInProcessObjectReference inProcessPopperWrapper;

    [Obsolete("Use the constructor taking a standard IJSObjectReference for the popperWrapper instead. This constructor will be removed in the next major version.")]
    public Instance(IJSObjectReference jSInstance, IJSInProcessObjectReference popperWrapper)
    {
        this.jSInstance = jSInstance;
        this.popperWrapper = popperWrapper;
        inProcessPopperWrapper = popperWrapper;
    }

    public Instance(IJSObjectReference jSInstance, IJSObjectReference popperWrapper)
    {
        this.jSInstance = jSInstance;
        this.popperWrapper = popperWrapper;
    }

    [Obsolete("This is only supported in Blazor WASM. Use GetStateAsync instead.")]
    public State State
    {
        get
        {
            if (inProcessPopperWrapper is null)
            {
                throw new InvalidOperationException("Getting the State property is only supported in Blazor WASM.");
            }
            return inProcessPopperWrapper.Invoke<State>("getStateOfInstance", jSInstance);
        }
    }

    public async Task<State> GetStateAsync()
    {
        return await popperWrapper.InvokeAsync<State>("getStateOfInstance", jSInstance);
    }

    public async Task ForceUpdate() => await jSInstance.InvokeVoidAsync("forceUpdate");
    public async Task<State> Update() => await popperWrapper.InvokeAsync<State>("updateOnInstance", jSInstance);
    public async Task<State> SetOptions(Options options) => await popperWrapper.InvokeAsync<State>("setOptionsOnInstance", jSInstance, options, options.objRef);
    public async Task Destroy() => await jSInstance.InvokeVoidAsync("destroy");
}
