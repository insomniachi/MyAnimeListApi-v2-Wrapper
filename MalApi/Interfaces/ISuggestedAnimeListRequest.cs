using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetSuggestedAnimeListRequest
{
    IGetSuggestedAnimeListRequest WithLimit(int limits);
    IGetSuggestedAnimeListRequest WithOffset(int offset);
    IGetSuggestedAnimeListRequest WithFields(params string[] fields);
    IGetSuggestedAnimeListRequest IncludeNsfw();
    Task<PagedAnime> Find();

    IGetSuggestedAnimeListRequest WithField<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
