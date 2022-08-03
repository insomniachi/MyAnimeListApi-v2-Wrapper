using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class MangaStatusConverter : JsonConverter<MangaStatus>
{
    public override MangaStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string status = reader.GetString();

        return status switch
        {
            "completed" => MangaStatus.Completed,
            "dropped" => MangaStatus.Dropped,
            "on_hold" => MangaStatus.OnHold,
            "plan_to_read" => MangaStatus.PlanToRead,
            "reading" => MangaStatus.Reading,
            _ => MangaStatus.None,
        };
    }

    public override void Write(Utf8JsonWriter writer, MangaStatus value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case MangaStatus.Completed:
                writer.WriteStringValue("completed");
                break;
            case MangaStatus.Dropped:
                writer.WriteStringValue("dropped");
                break;
            case MangaStatus.OnHold:
                writer.WriteStringValue("on_hold");
                break;
            case MangaStatus.PlanToRead:
                writer.WriteStringValue("plan_to_read");
                break;
            case MangaStatus.Reading:
                writer.WriteStringValue("reading");
                break;
        }
    }
}
