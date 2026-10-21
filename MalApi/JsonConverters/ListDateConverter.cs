using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

/// <summary>
/// A list entry's start or finish date. MAL lets users enter only a year or a year and month ("2020", "2020-05");
/// those read as default rather than a made-up day, which would be written back to MAL if the entry is saved.
/// </summary>
public class ListDateConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.TryParseExact(reader.GetString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)
            ? date
            : default;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
    }
}
