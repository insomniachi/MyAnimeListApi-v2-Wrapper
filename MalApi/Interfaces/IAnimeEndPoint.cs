namespace MalApi.Interfaces;

public interface IAnimeEndPoint
{
    IGetAnimeRequest WithId(long id);
    IGetAnimeListRequest WithName(string name);
    IUserAnimeListRequest OfUser(string user = "@me");
    IGetSeasonalAnimeListRequest OfSeason(AnimeSeason season, int year);
    IGetSuggestedAnimeListRequest SuggestedForMe();
    IGetRankedAnimeListRequest Top(AnimeRankingType rankingType);
}
