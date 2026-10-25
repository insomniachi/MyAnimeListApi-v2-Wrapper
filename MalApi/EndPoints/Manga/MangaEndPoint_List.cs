using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;

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
            ["nsfw"] = ShowNsfw.ToMal()
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = Http.WithQuery($"https://api.myanimelist.net/v2/manga", @params);

        return await ParsePagedManga(url);
    }

    IGetMangaListRequest IGetMangaListRequest.IncludeNsfw() => IncludeNsfw();

    IGetMangaListRequest IGetMangaListRequest.WithFields(params string[] fields) => WithFields(fields);

    IGetMangaListRequest IGetMangaListRequest.WithLimit(int limit) => WithLimit(limit);

    IGetMangaListRequest IGetMangaListRequest.WithOffset(int offset) => WithOffset(offset);
}
