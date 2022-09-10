using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint
{
    public long Id { get; set; }
    public List<string> Fields { get; set; } = new();
    public string Name { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int MaxLimit { get; set; }
    public AnimeRankingType RankingType { get; set; } = AnimeRankingType.Airing;
    public int Year { get; set; }
    public AnimeSeason Season { get; set; }
    public SeasonalAnimeSort SeasonalAnimeSort { get; set; } = SeasonalAnimeSort.NumberOfUsers;
    public string User { get; set; }
    public AnimeStatus Status { get; set; } = AnimeStatus.None;
    public UserItemSort UserAnimeSort { get; set; } = UserItemSort.UserScore;
    public bool? IsRewatching { get; set; }
    public Score? Score { get; set; }
    public int? EpisodesWatched { get; set; }
    public Priority? Priority { get; set; }
    public int? RewatchCount { get; set; }
    public Value? RewatchValue { get; set; }
    public string Tags { get; set; }
    public string Comments { get; set; }
    public bool ShowNsfw { get; set; }

    private AnimeEndPoint WithFields(params string[] fields)
    {
        foreach (var item in fields)
        {
            if (!Fields.Contains(item))
            {
                Fields.Add(item);
            }
        }
        return this;
    }

    private AnimeEndPoint WithLimit(int limit)
    {
        if (Limit > MaxLimit)
        {
            throw new ArgumentException($"argument greater than max value {MaxLimit}", nameof(limit));
        }

        Limit = limit;
        return this;
    }

    private AnimeEndPoint WithOffset(int offset)
    {
        Offset = offset;
        return this;
    }

    private AnimeEndPoint WithStatus(AnimeStatus status)
    {
        Status = status;
        return this;
    }

    private AnimeEndPoint WithComments(string comments)
    {
        Comments = comments;
        return this;
    }

    private AnimeEndPoint WithEpisodesWatched(int episodesWatched)
    {
        EpisodesWatched = episodesWatched;
        return this;
    }

    private AnimeEndPoint WithIsRewatching(bool rewatching)
    {
        IsRewatching = rewatching;
        return this;
    }

    private AnimeEndPoint WithPriority(Priority priority)
    {
        Priority = priority;
        return this;
    }

    private AnimeEndPoint WithRewatchCount(int rewatchCount)
    {
        RewatchCount = rewatchCount;
        return this;
    }

    private AnimeEndPoint WithRewatchValue(Value rewatchValue)
    {
        RewatchValue = rewatchValue;
        return this;
    }

    private AnimeEndPoint WithTags(string tags)
    {
        Tags = tags;
        return this;
    }

    private AnimeEndPoint WithScore(Score score)
    {
        Score = score;
        return this;
    }
    
    private AnimeEndPoint SortBy(UserItemSort sort)
    {
        UserAnimeSort = sort;
        return this;
    }

    public IGetSeasonalAnimeListRequest SortBy(SeasonalAnimeSort sort)
    {
        SeasonalAnimeSort = sort;
        return this;
    }

    private AnimeEndPoint IncludeNsfw()
    {
        ShowNsfw = true;
        return this;
    }

    private async Task<T> Parse<T>(string url)
    {
        var stream = await _client.GetStreamAsync(url);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }

    private async Task<PagedAnime> ParsePagedAnime(string url)
    {
        var root = await Parse<AnimeListRoot>(url);

        return new PagedAnime
        {
            Paging = root.Paging,
            Data = root.AnimeList.Select(x => x.Anime).ToList()
        };
    }

    private async Task<PagedRankedAnime> ParsePagedRankedAnime(string url)
    {
        var root = await Parse<AnimeListRoot>(url);

        return new PagedRankedAnime
        {
            Paging = root.Paging,
            Data = root.AnimeList.Select(x => new RankedAnime { Anime = x.Anime, Ranking = x.Ranking}).ToList()
        };
    }

    private async Task<Anime> ParseAnime(string url) => await Parse<Anime>(url);
}
