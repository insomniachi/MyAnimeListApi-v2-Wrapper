using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class AiringStatusConverter : JsonConverter<AiringStatus>
{
    public override AiringStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();

        return text switch
        {
            "finished_airing" => AiringStatus.FinishedAiring,
            "currently_airing" => AiringStatus.CurrentlyAiring,
            "not_yet_aired" => AiringStatus.NotYetAired,
            _ => AiringStatus.NotYetAired,
        };
    }

    public override void Write(Utf8JsonWriter writer, AiringStatus value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case AiringStatus.FinishedAiring:
                writer.WriteStringValue("finished_airing");
                break;
            case AiringStatus.CurrentlyAiring:
                writer.WriteStringValue("currently_airing");
                break;
            case AiringStatus.NotYetAired:
                writer.WriteStringValue("not_yet_aired");
                break;
        }
    }
}
