using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.Popper.JsonConverters
{
    class FnConverter : JsonConverter<Func<ModifierArguments, State?>>
    {
        public override Func<ModifierArguments, State> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Func<ModifierArguments, State> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    class PlacementConverter : JsonConverter<Placement>
    {
        public override Placement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Placement value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case Placement.Bottom: writer.WriteStringValue("bottom"); break;
                default: writer.WriteStringValue("top"); break;
            }
        }
    }

    class ActionStateConverter : JsonConverter<Action<State>>
    {
        public override Action<State> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Action<State> value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(Guid.NewGuid());
        }
    }
}
