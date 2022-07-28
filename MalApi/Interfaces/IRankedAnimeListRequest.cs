using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetRankedAnimeListRequest
{
    IGetRankedAnimeListRequest Top(AnimeRankingType rankingType);
    IGetRankedAnimeListRequest WithLimit(int limits);
    IGetRankedAnimeListRequest WithOffset(int offset);
    IGetRankedAnimeListRequest WithFields(params string[] fields);
    Task<PagedRankedAnime> Find();

    IGetRankedAnimeListRequest WithFields<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}