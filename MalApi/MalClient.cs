using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.EndPoints;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi;

public sealed class MalClient : IMalClient
{
    private readonly HttpClient _client = new();

    public void SetAccessToken(string accessToken)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        IsAuthenticated = true;
    }

    public void SetClientId(string id)
    {
        _client.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", id);
    }

    public bool IsAuthenticated { get; set; }

    public void Dispose() => _client.Dispose();

    public IAnimeEndPoint Anime() => new AnimeEndPoint(_client);
    public IMangaEndPoint Manga() => new MangaEndPoint(_client);
    public IForumEndPoint Forum() => new ForumEndPoint(_client);

    public async Task<MalUser> User()
    {
        var url = QueryHelpers.AddQueryString("https://api.myanimelist.net/v2/users/@me", new Dictionary<string, string>
        {
            ["fields"] = "anime_statistics"
        });

        var stream = await _client.GetStreamAsync(url);
        return await JsonSerializer.DeserializeAsync<MalUser>(stream);
    }

    public async Task<PagedAnime> GetNextAnimePage(PagedAnime pagedData)
    {
        var stream = await _client.GetStreamAsync(pagedData.Paging.Next);
        var root = await JsonSerializer.DeserializeAsync<AnimeListRoot>(stream);
     
        return new PagedAnime
        {
            Paging = root.Paging,
            Data = root.AnimeList.Select(x => x.Anime).ToList()
        };
    }
}
