using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class NsfwConverter : JsonConverter<NsfwLevel>
{
    public override NsfwLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();

        return text switch
        {
            "white" => NsfwLevel.White,
            "gray" => NsfwLevel.Gray,
            "black" => NsfwLevel.Black,
            _ => NsfwLevel.White,
        };
    }

    public override void Write(Utf8JsonWriter writer, NsfwLevel value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToLower());
    }
}
