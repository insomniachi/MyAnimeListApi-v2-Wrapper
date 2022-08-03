using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class MangaMediaTypeConverter : JsonConverter<MangaMediaType>
{
    public override MangaMediaType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();

        return text switch
        {
            "unknown" => MangaMediaType.Unknown,
            "manga" => MangaMediaType.Manga,
            "novel" => MangaMediaType.Novel,
            "one_shot" => MangaMediaType.OneShot,
            "doujinshi" => MangaMediaType.Doujinshi,
            "manhwa" => MangaMediaType.Manhwa,
            "manhua" => MangaMediaType.Manhua,
            "oel" => MangaMediaType.Oel,
            _ => MangaMediaType.Unknown,
        };
    }

    public override void Write(Utf8JsonWriter writer, MangaMediaType value, JsonSerializerOptions options)
    {
        if(value == MangaMediaType.OneShot)
        {
            writer.WriteStringValue("one_shot");
        }
        else
        {
            writer.WriteStringValue(value.ToString().ToLower());
        }
    }
}
