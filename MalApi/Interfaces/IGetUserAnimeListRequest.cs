using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using MalApi.Requests;

namespace MalApi.Interfaces;

public interface IUserAnimeListRequest
{
    IUserAnimeListRequest WithFields(params string[] fields);
    IUserAnimeListRequest WithOffset(int offset);
    IUserAnimeListRequest WithLimit(int limit);
    IUserAnimeListRequest SortBy(UserAnimeSort sort);
    IUserAnimeListRequest WithStatus(AnimeStatus status);
    Task<PagedAnime> Find();

    IUserAnimeListRequest WithField<T>(Expression<Func<Anime,T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
