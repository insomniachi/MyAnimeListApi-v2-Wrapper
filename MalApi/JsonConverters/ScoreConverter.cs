using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class ScoreConverter : JsonConverter<Score>
{
    public override Score Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var score = reader.GetInt32();
        return (Score)score;
    }

    public override void Write(Utf8JsonWriter writer, Score value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(((int)value).ToString());
    }
}
