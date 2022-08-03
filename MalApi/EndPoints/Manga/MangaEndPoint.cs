using MalApi.Interfaces;

namespace MalApi.EndPoints;
internal partial class MangaEndPoint : IMangaEndPoint
{
    public IUserMangaListRequest OfUser(string user = "@me")
    {
        return this;
    }

    public IGetRankedMangaListRequest Top(MangaRankingType rankingType)
    {
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
        return this;
    }
}
