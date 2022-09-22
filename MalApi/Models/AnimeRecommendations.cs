using System.Text.Json.Serialization;

namespace MalApi;

public class AnimeRecommendations
{
    [JsonPropertyName("node")]
    public Anime Anime { get; set; }

    [JsonPropertyName("num_recommendations")]
    public int NumberOfRecommendations { get; set; }
}
