using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint : IGetSuggestedAnimeListRequest
{
    async Task<PagedAnime> IGetSuggestedAnimeListRequest.Find()
    {
        var @params = new Dictionary<string, string>
        {
            ["limit"] = Limit.ToString(),
            ["offset"] = Offset.ToString(),
            ["nsfw"] = ShowNsfw.ToMal()
        };

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = Http.WithQuery("https://api.myanimelist.net/v2/anime/suggestions", @params);

        return await ParsePagedAnime(url);
    }

    IGetSuggestedAnimeListRequest IGetSuggestedAnimeListRequest.IncludeNsfw() => IncludeNsfw();
    IGetSuggestedAnimeListRequest IGetSuggestedAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IGetSuggestedAnimeListRequest IGetSuggestedAnimeListRequest.WithLimit(int limit) => WithLimit(limit);
    IGetSuggestedAnimeListRequest IGetSuggestedAnimeListRequest.WithOffset(int offset) => WithOffset(offset);
}
