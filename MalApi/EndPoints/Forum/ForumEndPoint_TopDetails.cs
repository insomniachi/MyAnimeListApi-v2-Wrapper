using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class ForumEndPoint : IGetForumTopicDetailsRequest
{
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithBoardId(int boardId) => WithBoardId(boardId);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithQuery(string query) => WithQuery(query);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithSubBoardId(int subBoardId) => WithSubBoardId(subBoardId);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithTopicUser(string name) => WithTopicUser(name);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithUser(string name) => WithUser(name);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithLimit(int limit) => WithLimit(limit);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithOffset(int offset) => WithOffset(offset);

    async Task<PagedForumTopicDetails> IGetForumTopicDetailsRequest.Find()
    {
        var url = Http.WithQuery("https://api.myanimelist.net/v2/forum/topics", GetParameters());
        var root = await _client.GetJson<ForumTopicDetailRoot>(url);
        return new PagedForumTopicDetails
        {
            Data = root.Details.ToList(),
            Paging = root.Paging
        };
    }

    private Dictionary<string,string> GetParameters()
    {
        var @params = GetPagingParameters();

        if(BoardId is { } boardId)
        {
            @params.Add("board_id", boardId.ToString());
        }

        if(SubBoardId is { } subId)
        {
            @params.Add("subboard_id", subId.ToString());
        }

        if(!string.IsNullOrEmpty(Query))
        {
            @params.Add("q", Query);
        }

        if(!string.IsNullOrEmpty(TopicUser))
        {
            @params.Add("topic_user_name", TopicUser);
        }

        if(!string.IsNullOrEmpty(User))
        {
            @params.Add("user_name", User);
        }

        return @params;
    }

    private Dictionary<string, string> GetPagingParameters()
    {
        var @params = new Dictionary<string, string> { ["offset"] = Offset.ToString() };

        if (Limit > 0)
        {
            @params.Add("limit", Limit.ToString());
        }

        return @params;
    }
}
