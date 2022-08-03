using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint : IUserAnimeListRequest, IUpdateRequest
{
    async Task<UserAnimeStatus> IUpdateRequest.Publish()
    {
        var url = $"https://api.myanimelist.net/v2/anime/{Id}/my_list_status";
        using var httpContent = new FormUrlEncodedContent(GetUpdateParams());
        httpContent.Headers.Clear();
        httpContent.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        var response = await _client.PutAsync(url, httpContent);
        var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<UserAnimeStatus>(stream);
    }

    async Task<PagedAnime> IUserAnimeListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
            ["sort"] = UserAnimeSort.GetMalApiString(),
        };

        if (Status != AnimeStatus.None)
        {
            @params.Add("status", Status.GetMalApiString());
        }

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/users/{User}/animelist", @params);

        return await ParsePagedAnime(url);
    }


    IUserAnimeListRequest IUserAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IUserAnimeListRequest IUserAnimeListRequest.WithLimit(int limit) => WithLimit(Limit);
    IUserAnimeListRequest IUserAnimeListRequest.WithOffset(int offset) => WithOffset(Offset);
    IUserAnimeListRequest IUserAnimeListRequest.WithStatus(AnimeStatus status) => WithStatus(status);
    IUserAnimeListRequest IUserAnimeListRequest.SortBy(UserAnimeSort sort) => SortBy(sort);

    IUpdateRequest IUpdateRequest.WithStatus(AnimeStatus status) => WithStatus(status);
    IUpdateRequest IUpdateRequest.WithTags(string tags) => WithTags(tags);
    IUpdateRequest IUpdateRequest.WithPriority(Priority priority) => WithPriority(priority);
    IUpdateRequest IUpdateRequest.WithRewatchCount(int rewatchCount) => WithRewatchCount(rewatchCount);
    IUpdateRequest IUpdateRequest.WithRewatchValue(RewatchValue rewatchValue) => WithRewatchValue(rewatchValue);
    IUpdateRequest IUpdateRequest.WithScore(Score score) => WithScore(score);
    IUpdateRequest IUpdateRequest.WithIsRewatching(bool rewatching) => WithIsRewatching(rewatching);
    IUpdateRequest IUpdateRequest.WithComments(string comments) => WithComments(comments);
    IUpdateRequest IUpdateRequest.WithEpisodesWatched(int episodesWatched) => WithEpisodesWatched(episodesWatched);

    private IDictionary<string, string> GetUpdateParams()
    {
        var @params = new Dictionary<string, string>();

        if (Status is not AnimeStatus.None)
        {
            @params.Add("status", Status.GetMalApiString());
        }

        if (IsRewatching is { } isRewatching)
        {
            @params.Add("is_rewatching", isRewatching.ToString());
        }

        if (Score is { } score)
        {
            @params.Add("score", ((int)score).ToString());
        }

        if (EpisodesWatched is { } ep)
        {
            @params.Add("num_watched_episodes", ep.ToString());
        }

        if (Priority is { } priority)
        {
            @params.Add("priority", ((int)priority).ToString());
        }

        if (RewatchCount is { } rewatchCount)
        {
            @params.Add("num_times_rewatched", rewatchCount.ToString());
        }

        if (RewatchValue is { } rewatchValue)
        {
            @params.Add("rewatch_value", ((int)rewatchValue).ToString());
        }

        if (string.IsNullOrEmpty(Tags) == false)
        {
            @params.Add("tags", Tags);
        }

        if (string.IsNullOrEmpty(Comments) == false)
        {
            @params.Add("comments", Comments);
        }

        return @params;
    }
}
