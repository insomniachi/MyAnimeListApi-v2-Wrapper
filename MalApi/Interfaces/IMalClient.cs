using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IMalClient
{
    IAnimeEndPoint Anime();
    Task<MalUser> User();
}
