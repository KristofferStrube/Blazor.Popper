﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.Popper
{
    class EnumDescriptionConverter<T> : JsonConverter<T> where T : IComparable, IFormattable, IConvertible
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string jsonValue = reader.GetString();

            foreach (var fi in typeToConvert.GetFields())
            {
                DescriptionAttribute description = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);

                if (description != null)
                {
                    if (description.Description == jsonValue)
                    {
                        return (T)fi.GetValue(null);
                    }
                }
            }
            throw new JsonException($"string {jsonValue} was not found as a description in the enum {typeToConvert}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute description = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);

            writer.WriteStringValue(description.Description);
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
