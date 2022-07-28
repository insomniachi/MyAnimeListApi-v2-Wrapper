using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetAnimeRequest
{
    IGetAnimeRequest WithFields(params string[] fields);
    IUpdateRequest UpdateStatus();
    Task<bool> RemoveFromList();
    Task<Anime> Find();

    IGetAnimeRequest WithField<T>(Expression<Func<Anime, T>> propExpr)
        => WithFields(ExpressionsHelper.GetJsonPropertyNames(propExpr));
}