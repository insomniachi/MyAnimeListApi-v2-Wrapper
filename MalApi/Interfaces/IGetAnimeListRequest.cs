using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetAnimeListRequest
{
    IGetAnimeListRequest WithLimit(int limit);
    IGetAnimeListRequest WithFields(params string[] fields);
    IGetAnimeListRequest WithOffset(int offset);
    Task<PagedAnime> Find();
}
