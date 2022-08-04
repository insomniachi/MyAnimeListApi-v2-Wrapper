using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IForumEndPoint
{
    Task<IEnumerable<ForumCategory>> GetBoards();
    IGetForumTopicDetailsRequest Topics();
    IGetForumTopicRequest Topic(int topicId);
}
