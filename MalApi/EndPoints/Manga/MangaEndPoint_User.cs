using System.Threading.Tasks;
using MalApi.Interfaces;

namespace MalApi.EndPoints;
internal partial class MangaEndPoint : IUserMangaListRequest, IUpdateMangaRequest
{
    public IUserMangaListRequest SortBy(UserItemSort sort)
    {
        throw new System.NotImplementedException();
    }

    Task<PagedManga> IUserMangaListRequest.Find()
    {
        throw new System.NotImplementedException();
    }

    IUserMangaListRequest IUserMangaListRequest.WithStatus(MangaStatus status) => WithStatus(status);

    IUserMangaListRequest IUserMangaListRequest.WithFields(params string[] fields) => WithFields(fields);

    IUserMangaListRequest IUserMangaListRequest.WithLimit(int limit) => WithLimit(limit);

    IUserMangaListRequest IUserMangaListRequest.WithOffset(int offset) => WithOffset(offset);
}
