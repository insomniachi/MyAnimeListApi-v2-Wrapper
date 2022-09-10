using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint : IGetRankedMangaListRequest
{
    async Task<PagedRankedManga> IGetRankedMangaListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["ranking_type"] = RankingType.ToString().ToLower(),
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
            ["nsfw"] = ShowNsfw.ToString()
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString("https://api.myanimelist.net/v2/manga/ranking", @params);

        return await ParsePagedRankedManga(url);
    }

    IGetRankedMangaListRequest IGetRankedMangaListRequest.IncludeNsfw() => IncludeNsfw();

    IGetRankedMangaListRequest IGetRankedMangaListRequest.WithFields(params string[] fields) => WithFields(fields);

    IGetRankedMangaListRequest IGetRankedMangaListRequest.WithLimit(int limits) => WithLimit(limits);

    IGetRankedMangaListRequest IGetRankedMangaListRequest.WithOffset(int offset) => WithOffset(offset);
}
