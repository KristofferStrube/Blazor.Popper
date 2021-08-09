using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class VirtualElement
    {
        public DotNetObjectReference<VirtualElement> objRef { get; set; }
        public VirtualElement()
        {
            objRef = DotNetObjectReference.Create(this);
        }
        [JsonIgnore]
        public Func<ClientRect> GetBoundingClientRect { get; set; }

        [JSInvokable("CallGetBoundingClientRect")]
        public ClientRect CallGetBoundingClientRect() => GetBoundingClientRect.Invoke();

        [JsonPropertyName("contextElement")]
        public ElementReference ContextElement { get; set; }
    }
}
