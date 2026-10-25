using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class ForumEndPoint : IGetForumTopicRequest
{
    public Task<PagedForumTopicData> Find() =>
        _client.GetJson<PagedForumTopicData>(Http.WithQuery($"https://api.myanimelist.net/v2/forum/topic/{TopicId}", GetPagingParameters()));

    IGetForumTopicRequest IGetForumTopicRequest.WithLimit(int limit) => WithLimit(limit);
    IGetForumTopicRequest IGetForumTopicRequest.WithOffset(int offset) => WithOffset(offset);
}
