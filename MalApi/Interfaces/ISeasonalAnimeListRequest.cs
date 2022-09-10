using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetSeasonalAnimeListRequest
{
    IGetSeasonalAnimeListRequest WithLimit(int limits);
    IGetSeasonalAnimeListRequest WithOffset(int offset);
    IGetSeasonalAnimeListRequest WithFields(params string[] fields);
    IGetSeasonalAnimeListRequest SortBy(SeasonalAnimeSort sort);
    IGetSuggestedAnimeListRequest IncludeNsfw();
    Task<PagedAnime> Find();

    IGetSeasonalAnimeListRequest WithField<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
