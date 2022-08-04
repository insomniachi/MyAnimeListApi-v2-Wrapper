using System;

namespace MalApi.EndPoints;

internal partial class ForumEndPoint
{
    public int? BoardId { get; set; }
    public int? SubBoardId { get; set; }
    public int TopicId { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int MaxLimit { get; set; }
    public string Query { get; set; }
    public string TopicUser { get; set; }
    public string User { get; set; }

    private ForumEndPoint WithUser(string name)
    {
        User = name;
        return this;
    }

    private ForumEndPoint WithTopicUser(string name)
    {
        TopicUser = name;
        return this;
    }

    private ForumEndPoint WithQuery(string query)
    {
        Query = query;
        return this;
    }

    private ForumEndPoint WithBoardId(int id)
    {
        BoardId = id;
        return this;
    }

    private ForumEndPoint WithSubBoardId(int id)
    {
        SubBoardId = id;
        return this;
    }

    private ForumEndPoint WithTopicId(int id)
    {
        TopicId = id;
        return this;
    }

    private ForumEndPoint WithLimit(int limit)
    {
        if (Limit > MaxLimit)
        {
            throw new ArgumentException($"argument greater than max value {MaxLimit}", nameof(limit));
        }

        Limit = limit;
        return this;
    }

    private ForumEndPoint WithOffset(int offset)
    {
        Offset = offset;
        return this;
    }
}
