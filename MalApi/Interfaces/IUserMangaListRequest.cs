using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace MalApi.Interfaces;

public interface IUserMangaListRequest
{
    IUserMangaListRequest WithFields(params string[] fields);
    IUserMangaListRequest WithOffset(int offset);
    IUserMangaListRequest WithLimit(int limit);
    IUserMangaListRequest SortBy(UserItemSort sort);
    IUserMangaListRequest WithStatus(MangaStatus status);
    IUserMangaListRequest IncludeNsfw();
    Task<PagedManga> Find();

    IUserMangaListRequest WithField<T>(Expression<Func<Manga, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
