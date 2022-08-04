using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.EndPoints;
using MalApi.Interfaces;
using MalApi.Requests;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi;

public sealed class MalClient : IMalClient
{
    private readonly HttpClient _client = new();

    public void SetAccessToken(string accessToken)
    {
        HttpRequest.AccessToken = accessToken;
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    }

    public void SetClientId(string id)
    {
        _client.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", id);
    }

    public bool IsAuthenticated => _client.DefaultRequestHeaders.Contains("Authorization");

    public void Dispose() => _client.Dispose();

    public IAnimeEndPoint Anime() => new AnimeEndPoint(_client);
    public IMangaEndPoint Manga() => new MangaEndPoint(_client);

    public async Task<MalUser> User()
    {
        var url = QueryHelpers.AddQueryString("https://api.myanimelist.net/v2/users/@me", new Dictionary<string, string>
        {
            ["fields"] = "anime_statistics"
        });

        var stream = await _client.GetStreamAsync(url);
        return await JsonSerializer.DeserializeAsync<MalUser>(stream);
    }


    public async Task<List<ForumCategory>> GetForumBoardsAsync()
    {
        var request = new GetForumBoardsRequest();

        return await request.GetAsync();
    }

    public async Task<ForumTopicData> GetForumTopicDetailsAsync(int id)
    {
        var request = new GetForumTopicDetailRequest(id);

        return await request.GetAsync();
    }

    public async Task<List<ForumTopicDetails>> GetForumTopicsAsync(string querry, int boardId =1, int subBoardId = -1 , string topicUser = "", string user = "")
    {
        var request = new GetForumTopicsRequest(querry, boardId, subBoardId, topicUser, user);

        return await request.GetAsync();
    }
}
