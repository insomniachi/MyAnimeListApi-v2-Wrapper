using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint : IGetSeasonalAnimeListRequest
{
    async Task<PagedAnime> IGetSeasonalAnimeListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["sort"] = SeasonalAnimeSort.GetMalApiString(),
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/anime/season/{Year}/{Season.ToString().ToLower()}", @params);

        return await ParsePagedAnime(url);
    }

    IGetSeasonalAnimeListRequest IGetSeasonalAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IGetSeasonalAnimeListRequest IGetSeasonalAnimeListRequest.WithLimit(int limit) => WithLimit(limit);
    IGetSeasonalAnimeListRequest IGetSeasonalAnimeListRequest.WithOffset(int offset) => WithOffset(offset);
    IGetSeasonalAnimeListRequest IGetSeasonalAnimeListRequest.SortBy(SeasonalAnimeSort sort) => SortBy(sort);
}
