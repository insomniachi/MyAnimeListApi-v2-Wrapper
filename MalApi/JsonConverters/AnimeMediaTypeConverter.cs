using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class AnimeMediaTypeConverter : JsonConverter<AnimeMediaType>
{
    public override AnimeMediaType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();

        return text switch
        {
            "unknown" => AnimeMediaType.Unknown,
            "tv" => AnimeMediaType.TV,
            "ova" => AnimeMediaType.OVA,
            "movie" => AnimeMediaType.Movie,
            "special" => AnimeMediaType.Special,
            "ona" => AnimeMediaType.ONA,
            "music" => AnimeMediaType.Music,
            _ => AnimeMediaType.Unknown,
        };
    }

    public override void Write(Utf8JsonWriter writer, AnimeMediaType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToLower());
    }
}
