namespace MalApi;

public static class EnumExtensions
{
    public static string GetMalApiString(this AnimeStatus status)
    {
        return status switch
        {
            AnimeStatus.Completed => "completed",
            AnimeStatus.Dropped => "dropped",
            AnimeStatus.OnHold => "on_hold",
            AnimeStatus.PlanToWatch => "plan_to_watch",
            AnimeStatus.Watching => "watching",
            _ => string.Empty,
        };
    }

    public static string GetMalApiString(this MangaStatus status)
    {
        return status switch
        {
            MangaStatus.Completed => "completed",
            MangaStatus.Dropped => "dropped",
            MangaStatus.OnHold => "on_hold",
            MangaStatus.PlanToRead => "plan_to_read",
            MangaStatus.Reading => "reading",
            _ => string.Empty,
        };
    }

    public static string GetMalApiStringForAnime(this UserItemSort sort)
    {
        return sort switch
        {
            UserItemSort.UserScore => "list_score",
            UserItemSort.LastUpdated => "list_updated_at",
            UserItemSort.Title => "anime_title",
            UserItemSort.StartDate => "anime_start_date",
            UserItemSort.Id => "anime_id ",
            _ => string.Empty
        };
    }

    public static string GetMalApiStringForManga(this UserItemSort sort)
    {
        return sort switch
        {
            UserItemSort.UserScore => "list_score",
            UserItemSort.LastUpdated => "list_updated_at",
            UserItemSort.Title => "manga_title",
            UserItemSort.StartDate => "manga_start_date",
            UserItemSort.Id => "manga_id ",
            _ => string.Empty
        };
    }

    public static string GetMalApiString(this SeasonalAnimeSort sort)
    {
        return sort switch
        {
            SeasonalAnimeSort.Score => "anime_score",
            SeasonalAnimeSort.NumberOfUsers => "anime_num_list_users",
            _ => throw new System.NotImplementedException(),
        };
    }

    public static AnimeStatus GetAnimeStatus(this string status)
    {
        return status switch
        {
            "completed" => AnimeStatus.Completed,
            "dropped" => AnimeStatus.Dropped,
            "on_hold" => AnimeStatus.OnHold,
            "plan_to_watch" => AnimeStatus.PlanToWatch,
            "watching" => AnimeStatus.Watching,
            _ => AnimeStatus.None,
        };
    }
}
