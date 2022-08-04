using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class ForumEndPoint : IForumEndPoint
{
    private readonly HttpClient _client;

    public ForumEndPoint(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ForumCategory>> GetBoards()
    {
        var stream = await _client.GetStreamAsync("https://api.myanimelist.net/v2/forum/boards");
        var root = await JsonSerializer.DeserializeAsync<ForumCategoryRoot>(stream);
        return root.Categories;
    }

    public IGetForumTopicRequest Topic(int topicId)
    {
        TopicId = topicId;
        return this;
    }

    public IGetForumTopicDetailsRequest Topics() => this;
}
