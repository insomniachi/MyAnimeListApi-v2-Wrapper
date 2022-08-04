using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetForumTopicRequest
{
    IGetForumTopicRequest WithLimit(int limit);
    IGetForumTopicRequest WithOffset(int offset);
    Task<PagedForumTopicData> Find();
}
