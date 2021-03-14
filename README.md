# MyAnimeListApi V2
.NET wrapper for official MyAnimeList API v2

```
var client = new MalClient("yourAccessToken");
```
[find out how to generate access token!](https://myanimelist.net/apiconfig/references/authorization)

## Available Functions
### Anime
* GetAnimeAsync
* SearchAnimeAsync
* GetSeasonalAnimeAsync
* GetUserAnimeAsync
* UpdateUserAnimeStatusAsync
* DeleteUserAnimeAsync
* GetRankedAnimeAsync
* GetSuggestedAnimeAsync

### User
* GetUserMeAsync

### Forum
* GetForumBoardsAsync
* GetForumTopicDetailsAsync
* GetForumTopicsAsync

### Manga
* GetMangaAsync
* GetRankedMangaAsync
* UpdateUserMangaStatusAsync