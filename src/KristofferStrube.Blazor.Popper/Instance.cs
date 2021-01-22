using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class Instance : IDisposable
    {
        private readonly IJSObjectReference jSInstance;
        private readonly DotNetObjectReference<Options> objRef;
        private readonly IJSInProcessObjectReference popperWrapper;

        public Instance(IJSObjectReference jSInstance, DotNetObjectReference<Options> objRef, IJSInProcessObjectReference popperWrapper)
        {
            this.jSInstance = jSInstance;
            this.objRef = objRef;
            this.popperWrapper = popperWrapper;
        }
        public State State
        {
            get { return popperWrapper.Invoke<State>("getStateOfInstance", jSInstance); }
        }
        public async Task ForceUpdate() => await jSInstance.InvokeVoidAsync("forceUpdate");
        public async Task<State> Update() => await popperWrapper.InvokeAsync<State>("updateOnInstance", jSInstance);
        public async Task<State> SetOptions(Options options) => await popperWrapper.InvokeAsync<State>("setOptionsOnInstance", jSInstance, options, objRef);
        public async Task Destroy() => await jSInstance.InvokeVoidAsync("destroy");

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            objRef?.Dispose();
        }
    }
}
