using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class ForumEndPoint : IGetForumTopicDetailsRequest
{
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithBoardId(int boardId) => WithBoardId(boardId);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithQuery(string query) => WithQuery(query);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithSubBoardId(int subBoardId) => WithSubBoardId(subBoardId);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithTopicUser(string name) => WithTopicUser(name);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithUser(string name) => WithUser(User);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithLimit(int limit) => WithLimit(limit);
    IGetForumTopicDetailsRequest IGetForumTopicDetailsRequest.WithOffset(int offset) => WithOffset(offset);
    
    async Task<PagedForumTopicDetails> IGetForumTopicDetailsRequest.Find()
    {
        var url = QueryHelpers.AddQueryString("https://api.myanimelist.net/v2/forum/topics", GetParameters());
        var stream = await _client.GetStreamAsync(url);
        var root = await JsonSerializer.DeserializeAsync<ForumTopicDetailRoot>(stream);
        return new PagedForumTopicDetails
        {
            Data = root.Details.ToList(),
            Paging = root.Paging
        };
    }

    private Dictionary<string,string> GetParameters()
    {
        var @params = new Dictionary<string, string>();

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
}
