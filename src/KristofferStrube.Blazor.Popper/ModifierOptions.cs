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
    public class OffsetOptions
    {
        public OffsetOptions(double skidding, double distance)
        {
            OffsetArray = new double[2] { skidding, distance };
        }
        public OffsetOptions(double skidding)
        {
            OffsetArray = new double[1] { skidding };
        }
        public OffsetOptions()
        {
            OffsetArray = new double[0];
        }

        public OffsetOptions(Func<PopperFunctionArguments, double[]> offsetsFunction)
        {
            OffsetsFunction = offsetsFunction;
            OffsetObjRef = DotNetObjectReference.Create(this);
        }

        [JsonPropertyName("offsetArray")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[] OffsetArray { get; set; }

        [JsonPropertyName("offsetObjRef")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DotNetObjectReference<OffsetOptions> OffsetObjRef { get; set; }

        [JsonIgnore]
        public Func<PopperFunctionArguments, double[]> OffsetsFunction { get; set; }

        [JSInvokable("CallOffsetsFunction")]
        public double[] CallOffsetsFunction(PopperFunctionArguments functionArguments) => OffsetsFunction?.Invoke(functionArguments);
    }
    public class PreventOverflowOptions
    {
        public PreventOverflowOptions(ElementReference boundary, double tetherOffsetNumber, bool mainAxis = true, bool altAxis = false, double padding = 0, bool altBoundary = false, RootBoundary rootBoundary = RootBoundary.Viewport, bool tether = true)
        {
            Boundary = boundary;
            MainAxis = mainAxis;
            AltAxis = altAxis;
            Padding = padding;
            AltBoundary = altBoundary;
            RootBoundary = rootBoundary;
            Tether = tether;
            TetherOffsetNumber = tetherOffsetNumber;
        }
        public PreventOverflowOptions(ElementReference boundary, Func<PopperFunctionArguments, double> tetherOffsetFunction, bool mainAxis = true, bool altAxis = false, double padding = 0, bool altBoundary = false, RootBoundary rootBoundary = RootBoundary.Viewport, bool tether = true)
        {
            Boundary = boundary;
            MainAxis = mainAxis;
            AltAxis = altAxis;
            Padding = padding;
            AltBoundary = altBoundary;
            RootBoundary = rootBoundary;
            Tether = tether;
            TetherOffsetFunction = tetherOffsetFunction;
            TetherOffsetObjRef = DotNetObjectReference.Create(this);
        }
        public PreventOverflowOptions(ElementReference boundary, bool mainAxis = true, bool altAxis = false, double padding = 0, bool altBoundary = false, RootBoundary rootBoundary = RootBoundary.Viewport, bool tether = true)
        {
            Boundary = boundary;
            MainAxis = mainAxis;
            AltAxis = altAxis;
            Padding = padding;
            AltBoundary = altBoundary;
            RootBoundary = rootBoundary;
            Tether = tether;
        }

        public PreventOverflowOptions() { }

        [JsonPropertyName("mainAxis")]
        public bool MainAxis { get; set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("altAxis")]
        public bool AltAxis { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
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
        [JsonPropertyName("tetherOffsetNumber")]
        public double TetherOffsetNumber { get; set; }

        [JsonPropertyName("tetherOffsetObjRef")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DotNetObjectReference<PreventOverflowOptions> TetherOffsetObjRef { get; set; }

        [JsonIgnore]
        public Func<PopperFunctionArguments, double> TetherOffsetFunction { get; set; }

        [JSInvokable("CallTetherOffsetFunction")]
        public double CallTetherOffsetFunction(PopperFunctionArguments functionArguments) => TetherOffsetFunction.Invoke(functionArguments);
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
