using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint
{
    private readonly HttpClient _client;

    public MangaEndPoint(HttpClient client)
    {
        _client = client;
    }

    public int Limit { get; set; }
    public int Offset { get; set; }
    public List<string> Fields { get; set; } = new();
    public int MaxLimit { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }
    public string User { get; set; }
    public MangaRankingType RankingType { get; set; }
    public MangaStatus Status { get; set; }
    public UserItemSort UserItemSort { get; set; }
    public Score? Score { get; set; }
    public int? Volumes { get; set; }
    public int? Chapters { get; set; }
    public Priority? Priority { get; set; }
    public int? RereadCount { get; set; }
    public Value? RereadValue { get; set; }
    public bool? IsRereading { get; set; }
    public string Tags { get; set; }
    public string Comments { get; set; }
    public bool ShowNsfw { get; set; }

    private MangaEndPoint WithTags(string tags)
    {
        Tags = tags;
        return this;
    }

    private MangaEndPoint WithComments(string comments)
    {
        Comments = comments;
        return this;
    }

    private MangaEndPoint WithIsRereading(bool isRereading)
    {
        IsRereading = isRereading;
        return this;
    }

    private MangaEndPoint WithScore(Score score)
    {
        Score = score;
        return this;
    }

    private MangaEndPoint WithVolumesRead(int volume)
    {
        Volumes = volume;
        return this;
    }

    private MangaEndPoint WithChaptersRead(int chapter)
    {
        Chapters = chapter;
        return this;
    }

    private MangaEndPoint WithPriority(Priority priority)
    {
        Priority = priority;
        return this;
    }

    private MangaEndPoint WithRereadCount(int rereadCount)
    {
        RereadCount = rereadCount;
        return this;
    }

    private MangaEndPoint WithRereadValue(Value value)
    {
        RereadValue = value;
        return this;
    }

    private MangaEndPoint WithFields(params string[] fields)
    {
        foreach (var item in fields)
        {
            if (!Fields.Contains(item))
            {
                if (item == "my_list_status" && User != "@me")
                {
                    Fields.Add("list_status");
                }
                else
                {
                    Fields.Add(item);
                }
            }
        }
        return this;
    }

    private MangaEndPoint WithLimit(int limit)
    {
        if (Limit > MaxLimit)
        {
            throw new ArgumentException($"argument greater than max value {MaxLimit}", nameof(limit));
        }

        Limit = limit;
        return this;
    }

    private MangaEndPoint WithOffset(int offset)
    {
        Offset = offset;
        return this;
    }

    private MangaEndPoint WithStatus(MangaStatus status)
    {
        Status = status;
        return this;
    }

    private MangaEndPoint SortBy(UserItemSort sort)
    {
        UserItemSort = sort;
        return this;
    }

    private MangaEndPoint IncludeNsfw()
    {
        ShowNsfw = true;
        return this;
    }

    private async Task<T> Parse<T>(string url)
    {
        var stream = await _client.GetStreamAsync(url);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }


    private async Task<PagedManga> ParsePagedManga(string url)
    {
        var root = await Parse<MangaListRoot>(url);

        foreach (var item in root.MangaList.Where(x => x.Status is not null))
        {
            item.Manga.UserStatus = item.Status;
        }

        return new PagedManga
        {
            Paging = root.Paging,
            Data = root.MangaList.Select(x => x.Manga).ToList()
        };
    }

    private async Task<PagedRankedManga> ParsePagedRankedManga(string url)
    {
        var root = await Parse<MangaListRoot>(url);

        return new PagedRankedManga
        {
            Paging = root.Paging,
            Data = root.MangaList.Select(x => new RankedManga { Manga = x.Manga, Ranking = x.Ranking }).ToList()
        };
    }

    private async Task<Manga> ParseManga(string url) => await Parse<Manga>(url);
}
