using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class State
    {
        [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }
    }
}
