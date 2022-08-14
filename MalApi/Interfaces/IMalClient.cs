using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IMalClient : IDisposable
{
    IAnimeEndPoint Anime();
    IMangaEndPoint Manga();
    IForumEndPoint Forum();
    Task<MalUser> User();
    void SetAccessToken(string token);
    void SetClientId(string id);
    bool IsAuthenticated { get; }
    Task<PagedAnime> GetNextAnimePage(PagedAnime pagedData);
}
