using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class OffsetOptions
    {
        [JsonPropertyName("offset")]
        public double[] Offset { get; set; }
    }
    public class PreventOverflowOptions
    {
        [JsonPropertyName("mainAxis")]
        public bool MainAxis { get; set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("altAxis")]
        public bool AltAxis { get; set; }

        [JsonPropertyName("padding")]
        public double Padding { get; set; }

        [JsonPropertyName("boundary")]
        public ElementReference Boundary { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("altBoundary")]
        public bool AltBoundary { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("rootBoundary")]
        public RootBoundary RootBoundary { get; set; }

        [JsonPropertyName("tether")]
        public bool Tether { get; set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("tetherOffset")]
        public double TetherOffset { get; set; }
    }

    public class ArrowOptions
    {
        [JsonPropertyName("element")]
        public ElementReference Element { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("padding")]
        public double Padding { get; set; }
    }

    public class FlipOptions
    {
        [JsonPropertyName("fallbackPlacements")]
        public Placement[] FallbackPlacements { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("padding")]
        public double Padding { get; set; }

        [JsonPropertyName("boundary")]
        public ElementReference Boundary { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("rootBoundary")]
        public RootBoundary RootBoundary { get; set; }

        [JsonPropertyName("flipVariations")]
        public bool FlipVariations { get; set; } = true;

        [JsonPropertyName("allowedAutoPlacements")]
        public Placement[] AllowedAutoPlacements { get; set; }
    }
}
