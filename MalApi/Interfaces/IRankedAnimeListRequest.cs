﻿using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetRankedAnimeListRequest
{
    IGetRankedAnimeListRequest WithLimit(int limits);
    IGetRankedAnimeListRequest WithOffset(int offset);
    IGetRankedAnimeListRequest WithFields(params string[] fields);
    IGetRankedAnimeListRequest IncludeNsfw();
    Task<PagedRankedAnime> Find();

    IGetRankedAnimeListRequest WithField<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
