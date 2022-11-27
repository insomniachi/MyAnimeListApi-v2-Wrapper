using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MalApi;

[DebuggerDisplay("{Title}")]
public class Video
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }
}
