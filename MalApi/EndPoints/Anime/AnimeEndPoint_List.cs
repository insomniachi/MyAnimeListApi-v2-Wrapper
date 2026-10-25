using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint : IGetAnimeListRequest
{
    async Task<PagedAnime> IGetAnimeListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["q"] = Name,
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
            ["nsfw"] = ShowNsfw.ToMal()
        };

        if(Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = Http.WithQuery($"https://api.myanimelist.net/v2/anime", @params);

        return await ParsePagedAnime(url);
    }

    IGetAnimeListRequest IGetAnimeListRequest.IncludeNsfw() => IncludeNsfw();
    IGetAnimeListRequest IGetAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IGetAnimeListRequest IGetAnimeListRequest.WithLimit(int limit) => WithLimit(limit);
    IGetAnimeListRequest IGetAnimeListRequest.WithOffset(int offset) => WithOffset(offset);
}
