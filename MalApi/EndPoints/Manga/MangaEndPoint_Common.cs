using System;
using System.Collections.Generic;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint
{
    public int Limit { get; set; }
    public int Offset { get; set; }
    public List<string> Fields { get; set; } = new();
    public int MaxLimit { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }
    public string User { get; set; }
    public MangaRankingType RankingType { get; set; }
    public MangaStatus Status { get; set; }

    private MangaEndPoint WithFields(params string[] fields)
    {
        foreach (var item in fields)
        {
            if (!Fields.Contains(item))
            {
                Fields.Add(item);
            }
        }
        return this;
    }

    private MangaEndPoint WithLimit(int limit)
    {
        if (Limit > MaxLimit)
        {
            throw new ArgumentException($"argument greater than max value {MaxLimit}", nameof(limit));
        }

        Limit = limit;
        return this;
    }

    private MangaEndPoint WithOffset(int offset)
    {
        Offset = offset;
        return this;
    }

    private MangaEndPoint WithStatus(MangaStatus status)
    {
        Status = status;
        return this;
    }
}
