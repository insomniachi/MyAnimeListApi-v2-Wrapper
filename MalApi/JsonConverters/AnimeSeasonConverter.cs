using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class AnimeSeasonConverter : JsonConverter<AnimeSeason>
{
    public override AnimeSeason Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var text = reader.GetString();
        return Enum.Parse<AnimeSeason>($"{text[..1].ToUpper()}{text[1..]}");
    }

    public override void Write(Utf8JsonWriter writer, AnimeSeason value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToLower());
    }
}
