using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;
internal partial class MangaEndPoint : IUserMangaListRequest, IUpdateMangaRequest
{

    async Task<PagedManga> IUserMangaListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
            ["sort"] = UserItemSort.GetMalApiStringForManga(),
        };

        if (Status != MangaStatus.None)
        {
            @params.Add("status", Status.GetMalApiString());
        }

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/users/{User}/animelist", @params);

        return await ParsePagedManga(url);
    }

    async Task<UserMangaStatus> IUpdateMangaRequest.Publish()
    {
        var url = $"https://api.myanimelist.net/v2/manga/{Id}/my_list_status";
        using var httpContent = new FormUrlEncodedContent(GetUpdateParams());
        httpContent.Headers.Clear();
        httpContent.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        var response = await _client.PutAsync(url, httpContent);
        var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<UserMangaStatus>(stream);
    }

    IUserMangaListRequest IUserMangaListRequest.WithStatus(MangaStatus status) => WithStatus(status);
    IUserMangaListRequest IUserMangaListRequest.WithFields(params string[] fields) => WithFields(fields);
    IUserMangaListRequest IUserMangaListRequest.WithLimit(int limit) => WithLimit(limit);
    IUserMangaListRequest IUserMangaListRequest.WithOffset(int offset) => WithOffset(offset);
    IUserMangaListRequest IUserMangaListRequest.SortBy(UserItemSort sort) => SortBy(sort);

    IUpdateMangaRequest IUpdateMangaRequest.WithStatus(MangaStatus status) => WithStatus(status);
    IUpdateMangaRequest IUpdateMangaRequest.WithIsRereading(bool isRereading) => WithIsRereading(isRereading);
    IUpdateMangaRequest IUpdateMangaRequest.WithScore(Score score) => WithScore(score);
    IUpdateMangaRequest IUpdateMangaRequest.WithVolumesRead(int volumes) => WithVolumesRead(volumes);
    IUpdateMangaRequest IUpdateMangaRequest.WithChaptersRead(int chapters) => WithChaptersRead(chapters);
    IUpdateMangaRequest IUpdateMangaRequest.WithPriority(Priority priority) => WithPriority(priority);
    IUpdateMangaRequest IUpdateMangaRequest.WithRereadCount(int rereadCount) => WithRereadCount(rereadCount);
    IUpdateMangaRequest IUpdateMangaRequest.WithRereadValue(Value rereadValue) => WithRereadValue(rereadValue);
    IUpdateMangaRequest IUpdateMangaRequest.WithTags(string tags) => WithTags(tags);
    IUpdateMangaRequest IUpdateMangaRequest.WithComments(string comments) => WithComments(comments);

    private IDictionary<string, string> GetUpdateParams()
    {
        var @params = new Dictionary<string, string>();

        if (Status is not MangaStatus.None)
        {
            @params.Add("status", Status.GetMalApiString());
        }

        if (IsRereading is { } isRereading)
        {
            @params.Add("is_rereading", isRereading.ToString());
        }

        if (Score is { } score)
        {
            @params.Add("score", ((int)score).ToString());
        }

        if (Volumes is { } v)
        {
            @params.Add("num_volumes_read", v.ToString());
        }

        if (Chapters is { } c)
        {
            @params.Add("num_chapters_read", c.ToString());
        }

        if (Priority is { } priority)
        {
            @params.Add("priority", ((int)priority).ToString());
        }

        if (RereadCount is { } rereadCount)
        {
            @params.Add("num_times_reread", rereadCount.ToString());
        }

        if (RereadValue is { } value)
        {
            @params.Add("rewatch_value", ((int)value).ToString());
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
