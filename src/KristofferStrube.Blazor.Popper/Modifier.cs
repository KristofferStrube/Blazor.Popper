using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
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
