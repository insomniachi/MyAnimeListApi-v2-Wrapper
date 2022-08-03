using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace MalApi.Interfaces;

public interface IGetMangaListRequest
{
    IGetMangaListRequest WithLimit(int limit);
    IGetMangaListRequest WithFields(params string[] fields);
    IGetMangaListRequest WithOffset(int offset);
    Task<PagedManga> Find();

    IGetMangaListRequest WithField<T>(Expression<Func<Manga, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
