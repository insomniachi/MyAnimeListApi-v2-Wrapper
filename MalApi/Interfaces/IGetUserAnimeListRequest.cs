using System.Threading.Tasks;
using MalApi.Requests;

namespace MalApi.Interfaces;

public interface IUserAnimeListRequest
{
    IUserAnimeListRequest WithFields(params string[] fields);
    IUserAnimeListRequest WithOffset(int offset);
    IUserAnimeListRequest WithLimit(int limit);
    IUserAnimeListRequest SortBy(UserAnimeSort sort);
    IUserAnimeListRequest WithStatus(AnimeStatus status);
    Task<PagedAnime> Find();
}
