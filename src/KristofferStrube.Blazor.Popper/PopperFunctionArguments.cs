using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public class PopperFunctionArguments
    {
        [JsonPropertyName("reference")]
        public Rect Reference { get; set; }

        [JsonPropertyName("popper")]
        public Rect Popper { get; set; }

        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }
    }
}
