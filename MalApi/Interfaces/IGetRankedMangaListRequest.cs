using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace MalApi.Interfaces;

public interface IGetRankedMangaListRequest
{
    IGetRankedMangaListRequest WithLimit(int limits);
    IGetRankedMangaListRequest WithOffset(int offset);
    IGetRankedMangaListRequest WithFields(params string[] fields);
    IGetRankedMangaListRequest IncludeNsfw();
    Task<PagedRankedManga> Find();

    IGetRankedMangaListRequest WithField<T>(Expression<Func<Manga, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
