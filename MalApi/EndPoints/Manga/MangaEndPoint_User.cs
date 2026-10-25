using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;

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
            ["nsfw"] = ShowNsfw.ToMal()
        };

        if (Status != MangaStatus.None)
        {
            @params.Add("status", Status.GetMalApiString());
        }

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = Http.WithQuery($"https://api.myanimelist.net/v2/users/{User}/mangalist", @params);

        return await ParsePagedManga(url);
    }

    async Task<UserMangaStatus> IUpdateMangaRequest.Publish()
    {
        var url = $"https://api.myanimelist.net/v2/manga/{Id}/my_list_status";
        using var httpContent = new FormUrlEncodedContent(GetUpdateParams());
        return await (await _client.PutAsync(url, httpContent)).ReadJson<UserMangaStatus>();
    }

    IUserMangaListRequest IUserMangaListRequest.WithStatus(MangaStatus status) => WithStatus(status);
    IUserMangaListRequest IUserMangaListRequest.WithFields(params string[] fields) => WithFields(fields);
    IUserMangaListRequest IUserMangaListRequest.WithLimit(int limit) => WithLimit(limit);
    IUserMangaListRequest IUserMangaListRequest.WithOffset(int offset) => WithOffset(offset);
    IUserMangaListRequest IUserMangaListRequest.SortBy(UserItemSort sort) => SortBy(sort);
    IUserMangaListRequest IUserMangaListRequest.IncludeNsfw() => IncludeNsfw();

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
    IUpdateMangaRequest IUpdateMangaRequest.WithStartDate(DateTime startDate) => WithStartDate(startDate);
    IUpdateMangaRequest IUpdateMangaRequest.WithFinishDate(DateTime finishDate) => WithFinishDate(finishDate);

    private IDictionary<string, string> GetUpdateParams()
    {
        var @params = new Dictionary<string, string>();

        if (Status is not MangaStatus.None)
        {
            @params.Add("status", Status.GetMalApiString());
        }

        if (IsRereading is { } isRereading)
        {
            @params.Add("is_rereading", isRereading.ToMal());
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
            @params.Add("reread_value", ((int)value).ToString());
        }

        if (string.IsNullOrEmpty(Tags) == false)
        {
            @params.Add("tags", Tags);
        }

        if (string.IsNullOrEmpty(Comments) == false)
        {
            @params.Add("comments", Comments);
        }

        if (StartDate is { } sd)
        {
            @params.Add("start_date", sd.ToString("yyyy-MM-dd"));
        }

        if (FinishDate is { } fd)
        {
            @params.Add("finish_date", fd.ToString("yyyy-MM-dd"));
        }

        return @params;
    }
}
