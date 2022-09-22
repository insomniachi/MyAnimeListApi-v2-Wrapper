using System.Text.Json.Serialization;
using MalApi.JsonConverters;

namespace MalApi;

public class StatusCounts
{
    [JsonConverter(typeof(StringToIntConverter))]
    [JsonPropertyName("watching")]
    public int Watching { get; set; }

    [JsonConverter(typeof(StringToIntConverter))]
    [JsonPropertyName("completed")]
    public int Completed { get; set; }

    [JsonConverter(typeof(StringToIntConverter))]
    [JsonPropertyName("on_hold")]
    public int OnHold { get; set; }

    [JsonConverter(typeof(StringToIntConverter))]
    [JsonPropertyName("dropped")]
    public int Dropped { get; set; }

    [JsonConverter(typeof(StringToIntConverter))]
    [JsonPropertyName("plan_to_watch")]
    public int PlanToWatch { get; set; }
}
