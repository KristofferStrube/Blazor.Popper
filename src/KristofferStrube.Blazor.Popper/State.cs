using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.Popper;

public class State
{
    [JsonPropertyName("attributes")]
    public Attributes Attributes { get; set; }

    [JsonPropertyName("elements")]
    public string[] Elements { get; set; }

    [JsonPropertyName("modifiersData")]
    public Dictionary<string, JsonElement> ModifiersData { get; set; }

    [JsonPropertyName("orderedModifiers")]
    public Modifier[] OrderedModifiers { get; set; }

    [JsonPropertyName("placement")]
    public Placement Placement { get; set; }
}

public class Attributes
{
    [JsonPropertyName("popper")]
    public PopperAttribute PopperAttribute { get; set; }
}

public class PopperAttribute
{
    [JsonPropertyName("data-popper-escaped")]
    public bool DataPopperEscaped { get; set; }

    [JsonPropertyName("data-popper-placement")]
    public Placement DataPopperPlacement { get; set; }

    [JsonPropertyName("data-popper-reference-hidden")]
    public bool DataPopperReferenceHidden { get; set; }
}
