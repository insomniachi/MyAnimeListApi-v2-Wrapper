using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint : IGetRankedAnimeListRequest
{
    async Task<PagedRankedAnime> IGetRankedAnimeListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["ranking_type"] = RankingType.ToString().ToLower(),
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString("https://api.myanimelist.net/v2/anime/ranking", @params);

        return await ParsePagedRankedAnime(url);
    }

    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.WithLimit(int limit) => WithLimit(limit);
    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.WithOffset(int offset) => WithOffset(offset);
}