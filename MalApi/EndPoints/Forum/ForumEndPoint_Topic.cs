using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class ForumEndPoint : IGetForumTopicRequest
{
    public async Task<PagedForumTopicData> Find()
    {
        var stream = await _client.GetStreamAsync($"https://api.myanimelist.net/v2/forum/topic/{TopicId}");
        return await JsonSerializer.DeserializeAsync<PagedForumTopicData>(stream);
    }

    IGetForumTopicRequest IGetForumTopicRequest.WithLimit(int limit) => WithLimit(limit);
    IGetForumTopicRequest IGetForumTopicRequest.WithOffset(int offset) => WithOffset(offset);
}
