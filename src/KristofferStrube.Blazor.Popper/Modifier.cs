using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class Modifier : IDisposable
    {
        public DotNetObjectReference<Modifier> objRef { get; set; }
        public Modifier(string Name, bool Enabled, ModifierPhases Phase, Func<ModifierArguments, State?> Fn)
        {
            this.Name = Name;
            this.Enabled = Enabled;
            this.Phase = Phase;
            this.Fn = Fn;
            objRef = DotNetObjectReference.Create(this);
        }

        // Required properties
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("phase")]
        public ModifierPhases Phase { get; set; }

        [JsonIgnore]
        public Func<ModifierArguments, State?> Fn { get; set; }
        [JSInvokable("CallFn")]
        public State? CallFn(ModifierArguments modifierArguments) => Fn(modifierArguments);

        // Optional properties

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("requires")]
        public string[] Requires { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("requiresIfExists")]
        public string[] RequiresIfExists { get; set; }

        [JsonIgnore]
        public Func<ModifierArguments, Action?> Effect { get; set; }
        [JSInvokable("CallEffect")]
        public Action? CallEffect(ModifierArguments modifierArguments) => Effect(modifierArguments);

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("options")]
        public object Options { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("data")]
        public object Data { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            objRef?.Dispose();
        }
    }
    public class ModifierArguments
    {
        public State State { get; set; }

        public string Name { get; set; }
    }
}
