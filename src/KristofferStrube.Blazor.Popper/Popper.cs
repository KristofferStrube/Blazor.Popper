using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.Popper
{
    public class Popper
    {
        private readonly IJSRuntime jSRuntime;

        public Popper(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task<Instance> CreatePopperAsync(ElementReference reference, ElementReference popper, Options options)
        {
            var objRef = DotNetObjectReference.Create(options);
            var popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/KristofferStrube.Blazor.Popper/KristofferStrube.Blazor.popper.js");
            var jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options, objRef);
            return new(jSInstance, objRef, popperWrapper);
        }
    }
}
