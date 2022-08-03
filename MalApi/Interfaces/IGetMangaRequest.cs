using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace MalApi.Interfaces;

public interface IGetMangaRequest
{
    IGetMangaRequest WithFields(params string[] fields);
    IUpdateMangaRequest UpdateStatus();
    Task<bool> RemoveFromList();
    Task<Manga> Find();
    IGetMangaRequest WithField<T>(Expression<Func<Manga, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}
