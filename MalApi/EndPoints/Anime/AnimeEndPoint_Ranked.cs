using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;

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
            ["nsfw"] = ShowNsfw.ToMal()
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = Http.WithQuery("https://api.myanimelist.net/v2/anime/ranking", @params);

        return await ParsePagedRankedAnime(url);
    }

    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.IncludeNsfw() => IncludeNsfw();
    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.WithLimit(int limit) => WithLimit(limit);
    IGetRankedAnimeListRequest IGetRankedAnimeListRequest.WithOffset(int offset) => WithOffset(offset);
}
