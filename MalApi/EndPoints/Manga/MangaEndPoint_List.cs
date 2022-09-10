using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint : IGetMangaListRequest
{
    async Task<PagedManga> IGetMangaListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["q"] = Name,
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
            ["nsfw"] = ShowNsfw.ToString()
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/manga", @params);

        return await ParsePagedManga(url);
    }

    IGetMangaListRequest IGetMangaListRequest.IncludeNsfw() => IncludeNsfw();

    IGetMangaListRequest IGetMangaListRequest.WithFields(params string[] fields) => WithFields(fields);

    IGetMangaListRequest IGetMangaListRequest.WithLimit(int limit) => WithLimit(limit);

    IGetMangaListRequest IGetMangaListRequest.WithOffset(int offset) => WithOffset(offset);
}
