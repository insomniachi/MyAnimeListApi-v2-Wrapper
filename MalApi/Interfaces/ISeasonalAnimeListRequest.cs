using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using MalApi.Requests;

namespace MalApi.Interfaces;

public interface IGetSeasonalAnimeListRequest
{
    IGetSeasonalAnimeListRequest WithLimit(int limits);
    IGetSeasonalAnimeListRequest WithOffset(int offset);
    IGetSeasonalAnimeListRequest WithFields(params string[] fields);
    IGetSeasonalAnimeListRequest SortBy(SeasonalAnimeSort sort);
    Task<PagedAnime> Find();

    IGetSeasonalAnimeListRequest WithFields<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}