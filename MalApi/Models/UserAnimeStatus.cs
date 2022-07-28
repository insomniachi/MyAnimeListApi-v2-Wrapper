using System;
using System.Text.Json.Serialization;
using MalApi.JsonConverters;

namespace MalApi
{
    public class UserAnimeStatus
    {
        [JsonPropertyName("status")]
        [JsonConverter(typeof(AnimeStatusConverter))]
        public AnimeStatus Status { get; set; }

        [JsonPropertyName("score")]
        [JsonConverter(typeof(ScoreConverter))]
        public Score Score { get; set; }

        [JsonPropertyName("num_episodes_watched")]
        public int WatchedEpisodes { get; set; }

        [JsonPropertyName("is_rewatching")]
        public bool IsRewatching { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("finish_date")]
        public DateTime FinishDate { get; set; }

        [JsonPropertyName("priority")]
        [JsonConverter(typeof(PriorityConverter))]
        public Priority Priority { get; set; }

        [JsonPropertyName("num_times_rewatched")]
        public int RewatchCount { get; set; }

        [JsonPropertyName("rewatch_value")]
        [JsonConverter(typeof(RewatchValueConverter))]
        public RewatchValue RewatchValue { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
