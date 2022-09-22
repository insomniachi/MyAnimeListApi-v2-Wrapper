using System.Text.Json.Serialization;
using MalApi.JsonConverters;

namespace MalApi;

public class RelatedManga
{
    [JsonPropertyName("node")]
    public Manga Manga { get; set; }

    [JsonConverter(typeof(RelationTypeConverter))]
    [JsonPropertyName("relation_type")]
    public RelationType RelationType { get; set; }

    [JsonPropertyName("relation_type_formatted")]
    public string RelationTypeFormatted { get; set; }
}
