using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IGetAnimeRequest
{
    IGetAnimeRequest WithFields(params string[] fields);
    IUpdateRequest UpdateStatus();
    Task<bool> RemoveFromList();
    Task<Anime> Find();
}