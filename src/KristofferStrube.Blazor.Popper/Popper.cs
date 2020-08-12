using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KristofferStrube.Blazor.Popper.JsonConverters;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.Popper
{
    public class Popper : IDisposable
    {
        private readonly IJSRuntime jSRuntime;
        private DotNetObjectReference<Options> objRef;

        public Popper(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task CreatePopperAsync(ElementReference reference, ElementReference popper, Options options)
        {
            objRef = DotNetObjectReference.Create(options);
            await jSRuntime.InvokeVoidAsync("PopperWrapper.createPopper", reference, popper, options, objRef);
        }
        public void Dispose()
        {
            objRef?.Dispose();
        }
    }

    public class Options
    {

        [JsonPropertyName("placement")]
        [JsonConverter(typeof(PlacementConverter))]
        public Placement Placement { get; set; }

        [JsonPropertyName("onFirstUpdate")]
        [JsonConverter(typeof(ActionStateConverter))]
        public Action<State> OnFirstUpdate { get; set; }

        [JSInvokable]
        public void CallAction(string guid, State state) => OnFirstUpdate.Invoke(state);

    }
    public class State
    {

    }
    public enum Placement
    {
        [Description("auto")]
        Auto,
        [Description("auto-start")]
        AutoStart,
        [Description("auto-end")]
        AutoEnd,
        [Description("top")]
        Top,
        [Description("top-start")]
        TopStart,
        [Description("top-end")]
        TopEnd,
        [Description("bottom")]
        Bottom,
        [Description("bottom-start")]
        BottomStart,
        [Description("bottom-end")]
        BottomEnd,
        [Description("right")]
        Right,
        [Description("right-start")]
        RightStart,
        [Description("right-end")]
        RightEnd,
        [Description("left")]
        Left,
        [Description("left-start")]
        LeftStart,
        [Description("left-end")]
        LeftEnd
    }
    public enum Strategy
    {
        [Description("absolute")]
        Absolute,
        [Description("fixed")]
        Fixed
    }
    public class Modifier
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("phase")]
        public string Phase { get; set; }

        [JsonPropertyName("fn")]
        public Func<ModifierArguments, State?> Fn { get; set; }

        [JsonPropertyName("requires")]
        public string[] Requires { get; set; }

        [JsonPropertyName("requiresIfExists")]
        public string[] RequiresIfExists { get; set; }

        [JsonPropertyName("effect")]
        public Func<ModifierArguments, Action?> Effect { get; set; }

        [JsonPropertyName("options")]
        public object Options { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
    public enum ModifierPhases
    {
        [Description("read")]
        Read,
        [Description("main")]
        Main,
        [Description("write")]
        Write
    }
    public class ModifierArguments
    {
        [Description("state")]
        public State State { get; set; }
        [Description("instance")]
        public object Instance { get; set; }
        [Description("options")]
        public Options Options { get; set; }
        [Description("name")]
        public string Name { get; set; }
    }
}
