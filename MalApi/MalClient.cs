using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MalApi.EndPoints;
using MalApi.Interfaces;

namespace MalApi;

public sealed class MalClient : IMalClient
{
    private const string ClientIdHeader = "X-MAL-CLIENT-ID";
    private readonly HttpClient _client = new();

    public void SetAccessToken(string accessToken)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        IsAuthenticated = true;
    }

    public void SetClientId(string id)
    {
        _client.DefaultRequestHeaders.Remove(ClientIdHeader);
        _client.DefaultRequestHeaders.Add(ClientIdHeader, id);
    }

    public bool IsAuthenticated { get; set; }

    public void Dispose() => _client.Dispose();

    public IAnimeEndPoint Anime() => new AnimeEndPoint(_client);
    public IMangaEndPoint Manga() => new MangaEndPoint(_client);
    public IForumEndPoint Forum() => new ForumEndPoint(_client);

    public Task<MalUser> User()
    {
        var url = Http.WithQuery("https://api.myanimelist.net/v2/users/@me", new Dictionary<string, string>
        {
            ["fields"] = "anime_statistics"
        });

        return _client.GetJson<MalUser>(url);
    }

    // Same parsing as the first page, so list statuses aren't dropped from later pages.
    public Task<PagedAnime> GetNextAnimePage(PagedAnime pagedData) => AnimeEndPoint.ParsePagedAnime(_client, pagedData.Paging.Next);
}
