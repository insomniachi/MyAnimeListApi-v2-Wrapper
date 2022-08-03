namespace MalApi.Interfaces;

public interface IMangaEndPoint
{
    IGetMangaRequest WithId(long id);
    IGetMangaListRequest WithName(string name);
    IGetRankedMangaListRequest Top(MangaRankingType rankingType);
    IUserMangaListRequest OfUser(string user = "@me");
}
