using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint : IGetRankedMangaListRequest
{
    Task<PagedRankedManga> IGetRankedMangaListRequest.Find()
    {
        throw new System.NotImplementedException();
    }

    IGetRankedMangaListRequest IGetRankedMangaListRequest.WithFields(params string[] fields) => WithFields(fields);

    IGetRankedMangaListRequest IGetRankedMangaListRequest.WithLimit(int limits) => WithLimit(limits);

    IGetRankedMangaListRequest IGetRankedMangaListRequest.WithOffset(int offset) => WithOffset(offset);
}
