using MalApi.Interfaces;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint : IAnimeEndPoint
{
    public AnimeEndPoint()
    {
    }

    public IGetSeasonalAnimeListRequest OfSeason(AnimeSeason season, int year)
    {
        Limit = 100;
        MaxLimit = 500;
        Year = year;
        Season = season;
        return this;
    }

    public IUserAnimeListRequest OfUser(string user = @"me")
    {
        User = user;
        Limit = 500;
        MaxLimit = 1000;
        return this;
    }

    public IGetSuggestedAnimeListRequest SuggestedForMe()
    {
        Limit = MaxLimit = 100;
        return this;
    }

    public IGetRankedAnimeListRequest Top(AnimeRankingType rankingType)
    {
        Limit = 100;
        MaxLimit = 500;
        RankingType = rankingType;
        return this;
    }

    public IGetAnimeRequest WithId(long id)
    {
        Id = id;
        return this;
    }

    public IGetAnimeListRequest WithName(string name)
    {
        Limit = MaxLimit = 100;
        Name = name;
        return this;
    }
}
