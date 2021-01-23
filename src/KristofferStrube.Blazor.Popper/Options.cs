using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.Popper
{
    public class Options : IDisposable
    {
        public DotNetObjectReference<Options> objRef { get; set; }

        public Options()
        {
            objRef = DotNetObjectReference.Create(this);
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("modifiers")]
        public Modifier[] Modifiers { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(EnumDescriptionConverter<Strategy>))]
        [JsonPropertyName("strategy")]
        public Strategy Strategy { get; set; }

        [JsonIgnore]
        public Action<State> OnFirstUpdate { get; set; }

        [JSInvokable("CallOnFirstUpdate")]
        public void CallOnFirstUpdate(State state) => OnFirstUpdate?.Invoke(state);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            objRef?.Dispose();
        }
    }
}
