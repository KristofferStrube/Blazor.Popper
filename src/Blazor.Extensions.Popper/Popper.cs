using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Extensions
{
    public class Popper
    {
        private readonly IJSRuntime jSRuntime;

        public Popper(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task CreatePopperAsync(ElementReference reference, ElementReference popper, object options)
        {
            await jSRuntime.InvokeVoidAsync("PopperWrapper.createPopper", reference, popper, options);
        }
    }
}
