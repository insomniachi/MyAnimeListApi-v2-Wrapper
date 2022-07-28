using System.Text.Json.Serialization;
using MalApi.JsonConverters;

namespace MalApi
{
    public class Anime
    {
        [JsonPropertyName(AnimeFieldNames.Id)]
        public int Id { get; set; }

        [JsonPropertyName(AnimeFieldNames.Title)]
        public string Title { get; set; }

        [JsonPropertyName(AnimeFieldNames.MainPicture)]
        public Picture MainPicture { get; set; }

        [JsonPropertyName(AnimeFieldNames.AlternativeTitles)]
        public AlternativeTitles AlternativeTitles { get; set; }

        [JsonPropertyName(AnimeFieldNames.StartDate)]
        public string StartDate { get; set; }

        [JsonPropertyName(AnimeFieldNames.EndDate)]
        public string EndDate { get; set; }

        [JsonPropertyName(AnimeFieldNames.Synopsis)]
        public string Synopsis { get; set; }

        [JsonPropertyName(AnimeFieldNames.Mean)]
        public float? MeanScore { get; set; }

        [JsonPropertyName(AnimeFieldNames.Rank)]
        public int? Rank { get; set; }

        [JsonPropertyName(AnimeFieldNames.Popularity)]
        public int? Popularity { get; set; }

        [JsonPropertyName(AnimeFieldNames.NumberOfUsers)]
        public int? NumberOfUsers { get; set; }

        [JsonPropertyName(AnimeFieldNames.NumberOfScoringUsers)]
        public int? NumberOfScoringUsers { get; set; }

        [JsonPropertyName(AnimeFieldNames.Nsfw)]
        [JsonConverter(typeof(NsfwConverter))]
        public NsfwLevel? NsfwLevel { get; set; }

        [JsonPropertyName(AnimeFieldNames.Genres)]
        public Genre[] Genres { get; set; }

        [JsonPropertyName(AnimeFieldNames.CreatedAt)]
        public string CreatedAt { get; set; }

        [JsonPropertyName(AnimeFieldNames.UpdatedAt)]
        public string UpdatedAt { get; set; }

        [JsonPropertyName(AnimeFieldNames.MediaType)]
        [JsonConverter(typeof(AnimeMediaTypeConverter))]
        public AnimeMediaType? MediaType { get; set; }

        [JsonPropertyName(AnimeFieldNames.Status)]
        [JsonConverter(typeof(AiringStatusConverter))]
        public AiringStatus? Status { get; set; }

        [JsonPropertyName(AnimeFieldNames.UserStatus)]
        public UserAnimeStatus UserStatus { get; set; }

        [JsonPropertyName(AnimeFieldNames.TotalEpisdoes)]
        public int? TotalEpisodes { get; set; }

        [JsonPropertyName(AnimeFieldNames.StartSeason)]
        public Season StartSeason { get; set; }

        [JsonPropertyName(AnimeFieldNames.Broadcast)]
        public BroadcastTime Broadcast { get; set; }

        [JsonPropertyName(AnimeFieldNames.Source)]
        [JsonConverter(typeof(AnimeSourceConverter))]
        public AnimeSource? Source { get; set; }

        [JsonPropertyName(AnimeFieldNames.AverageEpisodeDuration)]
        public int? AverageEpisodeDuration { get; set; }

        [JsonPropertyName(AnimeFieldNames.Rating)]
        public string CensorRating { get; set; }

        [JsonPropertyName(AnimeFieldNames.Studios)]
        public Studio[] Studios { get; set; }

        [JsonPropertyName(AnimeFieldNames.Pictures)]
        public Picture[] Pictures { get; set; }

        [JsonPropertyName(AnimeFieldNames.Background)]
        public string Background { get; set; }

        public override string ToString() => Title;
    }
}
