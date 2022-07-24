using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetSuggestedAnimeListRequest
{
    IGetSuggestedAnimeListRequest WithLimit(int limits);
    IGetSuggestedAnimeListRequest WithOffset(int offset);
    IGetSuggestedAnimeListRequest WithFields(params string[] fields);
    Task<PagedAnime> Find();
}