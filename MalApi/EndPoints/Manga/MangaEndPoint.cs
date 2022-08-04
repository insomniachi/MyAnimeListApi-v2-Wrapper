using MalApi.Interfaces;

namespace MalApi.EndPoints;
internal partial class MangaEndPoint : IMangaEndPoint
{
    public IUserMangaListRequest OfUser(string user = "@me")
    {
        User = user;
        Limit = 500;
        MaxLimit = 1000;
        return this;
    }

    public IGetRankedMangaListRequest Top(MangaRankingType rankingType)
    {
        RankingType = rankingType;
        Limit = 100;
        MaxLimit = 500;
        return this;
    }

    public IGetMangaRequest WithId(long id)
    {
        Id = id;
        return this;
    }

    public IGetMangaListRequest WithName(string name)
    {
        Name = name;
        Limit = MaxLimit = 100;
        return this;
    }
}
