using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IUserAnimeListRequest
{
    IUserAnimeListRequest WithFields(params string[] fields);
    IUserAnimeListRequest WithOffset(int offset);
    IUserAnimeListRequest WithLimit(int limit);
    IUserAnimeListRequest SortBy(UserItemSort sort);
    IUserAnimeListRequest WithStatus(AnimeStatus status);
    Task<PagedAnime> Find();

    IUserAnimeListRequest WithField<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
