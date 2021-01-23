using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class Instance
    {
        private readonly IJSObjectReference jSInstance;
        private readonly IJSInProcessObjectReference popperWrapper;

        public Instance(IJSObjectReference jSInstance, IJSInProcessObjectReference popperWrapper)
        {
            this.jSInstance = jSInstance;
            this.popperWrapper = popperWrapper;
        }
        public State State
        {
            get { return popperWrapper.Invoke<State>("getStateOfInstance", jSInstance); }
        }
        public async Task ForceUpdate() => await jSInstance.InvokeVoidAsync("forceUpdate");
        public async Task<State> Update() => await popperWrapper.InvokeAsync<State>("updateOnInstance", jSInstance);
        public async Task<State> SetOptions(Options options) => await popperWrapper.InvokeAsync<State>("setOptionsOnInstance", jSInstance, options, options.objRef);
        public async Task Destroy() => await jSInstance.InvokeVoidAsync("destroy");
    }
}
