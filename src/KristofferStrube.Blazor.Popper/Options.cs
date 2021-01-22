using System;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.Popper
{
    public class Options
    {
        [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }

        [JsonIgnore]
        public Action<State> OnFirstUpdate { get; set; }

        [JSInvokable("CallOnFirstUpdate")]
        public void CallOnFirstUpdate(State state) => OnFirstUpdate?.Invoke(state);
    }
}
