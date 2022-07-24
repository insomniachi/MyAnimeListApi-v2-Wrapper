using System.Threading.Tasks;
using MalApi.Requests;

namespace MalApi.Interfaces;

public interface IGetAnimeRequest
{
    IGetAnimeRequest WithFields(params string[] fields);
    IUpdateRequest UpdateStatus();
    Task<Anime> Find();
}