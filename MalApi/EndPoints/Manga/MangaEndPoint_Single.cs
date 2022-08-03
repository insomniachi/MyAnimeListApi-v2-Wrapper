using System;
using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint : IGetMangaRequest
{
    public Task<Manga> Find()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveFromList()
    {
        throw new NotImplementedException();
    }

    public IUpdateMangaRequest UpdateStatus() => this;

    IGetMangaRequest IGetMangaRequest.WithFields(params string[] fields) => WithFields(fields);
}
