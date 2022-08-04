using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

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
        };

        if(Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/anime", @params);

        return await ParsePagedAnime(url);
    }

    IGetAnimeListRequest IGetAnimeListRequest.WithFields(params string[] fields) => WithFields(fields);
    IGetAnimeListRequest IGetAnimeListRequest.WithLimit(int limit) => WithLimit(limit);
    IGetAnimeListRequest IGetAnimeListRequest.WithOffset(int offset) => WithOffset(offset);
}
