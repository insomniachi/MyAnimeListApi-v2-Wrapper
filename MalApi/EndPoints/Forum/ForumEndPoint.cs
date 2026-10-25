using System.Collections.Generic;
using System.Net.Http;
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
        var root = await _client.GetJson<ForumCategoryRoot>("https://api.myanimelist.net/v2/forum/boards");
        return root.Categories;
    }

    public IGetForumTopicRequest Topic(int topicId)
    {
        TopicId = topicId;
        MaxLimit = 100;
        return this;
    }

    public IGetForumTopicDetailsRequest Topics()
    {
        MaxLimit = 100;
        return this;
    }
}
