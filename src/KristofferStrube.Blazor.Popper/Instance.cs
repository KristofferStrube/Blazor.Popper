using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper;

/// <summary>
/// 
/// </summary>
public class Instance
{
    /// <summary>
    /// The Popper JavaScript instance on "createPopper".
    /// </summary>
    private readonly IJSObjectReference jSInstance;
    /// <summary>
    /// The Popper.js wrapper
    /// </summary>
    private readonly IJSObjectReference popperWrapper;

    /// <summary>
    /// Initializes a new JavaScript Popper <see cref="Instance"/>.
    /// </summary>
    /// <param name="jSInstance">The JavaScript Popper instance.</param>
    /// <param name="popperWrapper">The Popper.js wrapper.</param>
    /// <seealso cref="Popper.CreatePopperAsync{T}(T, Microsoft.AspNetCore.Components.ElementReference, Options)"/>
    public Instance(IJSObjectReference jSInstance, IJSInProcessObjectReference popperWrapper)
    {
        this.jSInstance = jSInstance;
        this.popperWrapper = popperWrapper;
    }
    /// <summary>
    /// Initializes a new JavaScript Popper <see cref="Instance"/>.
    /// </summary>
    /// <param name="jSInstance">The JavaScript Popper instance.</param>
    /// <param name="popperWrapper">The Popper.js wrapper.</param>
    public Instance(IJSObjectReference jSInstance, IJSObjectReference popperWrapper)
    {
        this.jSInstance = jSInstance;
        this.popperWrapper = popperWrapper;
    }
    /// <summary>
    /// Gets the state of the Popper instance.
    /// </summary>
    /// <value>
    /// The state of the Popper instance.
    /// </value>
    public State State
    {
        get { return ((IJSInProcessObjectReference)popperWrapper).Invoke<State>("getStateOfInstance", jSInstance); }
    }

    /// <summary>
    /// Gets the state asynchronously.
    /// </summary>
    /// <returns>The state of the Popper instance.</returns>
    public async Task<State> GetStateAsync()
    {
        if (popperWrapper is IJSInProcessObjectReference inProcessPopperWrapper)
        {
            return inProcessPopperWrapper.Invoke<State>("getStateOfInstance", jSInstance);
        }
        return await popperWrapper.InvokeAsync<State>("getStateOfInstance", jSInstance);
    }

    /// <summary>
    /// Forces an update on the Popper instance.
    /// </summary>
    public async Task ForceUpdate() => await jSInstance.InvokeVoidAsync("forceUpdate");
    /// <summary>
    /// Updates this instance.
    /// </summary>
    /// <returns>The state of the Popper instance after update.</returns>
    public async Task<State> Update() => await popperWrapper.InvokeAsync<State>("updateOnInstance", jSInstance);
    /// <summary>
    /// Sets the Popper instance options.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <returns>The state of the Popper instance after setting the options.</returns>
    public async Task<State> SetOptions(Options options) => await popperWrapper.InvokeAsync<State>("setOptionsOnInstance", jSInstance, options, options.objRef);
    /// <summary>
    /// Destroys this Popper instance.
    /// </summary>
    public async Task Destroy() => await jSInstance.InvokeVoidAsync("destroy");
}
