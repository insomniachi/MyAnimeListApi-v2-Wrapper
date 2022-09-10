using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetAnimeListRequest
{
    IGetAnimeListRequest WithLimit(int limit);
    IGetAnimeListRequest WithFields(params string[] fields);
    IGetAnimeListRequest WithOffset(int offset);
    IGetAnimeListRequest IncludeNsfw();
    Task<PagedAnime> Find();

    IGetAnimeListRequest WithField<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
