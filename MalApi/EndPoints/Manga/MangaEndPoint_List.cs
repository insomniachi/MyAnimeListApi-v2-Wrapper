using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint : IGetMangaListRequest
{
    Task<PagedManga> IGetMangaListRequest.Find()
    {
        throw new System.NotImplementedException();
    }

    IGetMangaListRequest IGetMangaListRequest.WithFields(params string[] fields) => WithFields(fields);

    IGetMangaListRequest IGetMangaListRequest.WithLimit(int limit) => WithLimit(limit);

    IGetMangaListRequest IGetMangaListRequest.WithOffset(int offset) => WithOffset(offset);
}
