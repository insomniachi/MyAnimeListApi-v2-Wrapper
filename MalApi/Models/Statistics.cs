using System.Text.Json.Serialization;

namespace MalApi;

public class Statistics
{
    [JsonPropertyName("num_list_users")]
    public int NumberOfUsers { get; set; }

    [JsonPropertyName("status")]
    public StatusCounts Status { get; set; }
}
