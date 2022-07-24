using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IDeleteRequest
{
    Task<bool> RemoveFromMyList();
}
