using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetForumTopicDetailsRequest
{
    IGetForumTopicDetailsRequest WithBoardId(int boardId);
    IGetForumTopicDetailsRequest WithSubBoardId(int subBoardId);
    IGetForumTopicDetailsRequest WithLimit(int limit);
    IGetForumTopicDetailsRequest WithOffset(int offset);
    IGetForumTopicDetailsRequest WithQuery(string query);
    IGetForumTopicDetailsRequest WithTopicUser(string name);
    IGetForumTopicDetailsRequest WithUser(string name);
    Task<PagedForumTopicDetails> Find();
}
