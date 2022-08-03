using System;
using System.Text.Json.Serialization;
using MalApi.JsonConverters;

namespace MalApi;

public sealed class Season : IEquatable<Season>
{
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("season")]
    [JsonConverter(typeof(AnimeSeasonConverter))]
    public AnimeSeason SeasonName { get; set; }

    public override string ToString()
    {
        return $"{SeasonName} {Year}";
    }

    public bool Equals(Season other)
    {
        return SeasonName == other.SeasonName && Year == other.Year;
    }

    public Season() { }

    public Season(AnimeSeason season, int year)
    {
        SeasonName = season;
        Year = year;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Season);
    }

    public override int GetHashCode() => HashCode.Combine(SeasonName, Year);
}
