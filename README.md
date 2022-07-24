# MyAnimeListApi V2
.NET wrapper for official MyAnimeList API v2

[How to generate (official documentaiton)](https://myanimelist.net/apiconfig/references/authorization)

MalApi provides a helper to generate token.
```
var url = MalAuthHelper.GetAuthUrl("<CLIENT_ID>");
```
will return an Auth url, you can paste this in your browser, you'll be prompted to authorize.
after authorizing, it will redirected to `<YOUR_REDIRECT_URI>?code=<AUTHORIZATION_CODE>`
copy the `AUTHORIZATION_CODE` and call
```
OAuthToken token = await MalAuthHelper.DoAuth("<CLIENT_ID>", "<AUTHORIZATION_CODE>")
```
this will contain both access and refresh tokens and is valid for 31 days

To refresh the token after expiry, do
```
OAuthToken token = await MalAuthHelper.RefreshToken("<CLIENT_ID>", "<REFRESH_TOKEN>")
```

## Usage
create instance of `MalClient`
```
var client = new MalClient("yourAccessToken");
```
Get anime    
```
Anime anime = await  client.Anime()
                           .WithId(420420)
                           .Find()
```
Search anime
```
PagedAnime anime = await  client.Anime()
                                .WithName("One piece")
                                .Find()
```
by default only Id,Title,and Image are returned by api
to get addition details use `WithFields()`.
```
Anime anime = await  client.Anime()
                           .WithId(1000)
                           .WithFields("my_list_status")
                           .Find()
```

Get user anime list
```
PagedAnime anime = await  client.Anime()
                                .OfUser("Mal_UserName") // if you don't give user name it return list of authenticated user.
                                .Find()
```
Update anime status
```
UserAnimeStatus status = await client.Anime()
                                     .WithId(696969) 
                                     .Update()
                                     .WithScore(7)
                                     .WithStatus(AnimeStatus.Watching)
                                     .WithIsRewatching(false)
                                     .WithEpisodesWatched(3)
                                     .WithPriority(1)
                                     .WithRewatchCount(0)
                                     .WithRewatchValue(1)
                                     .WithTags("tags")
                                     .WithComments("comment")
                                     .Publish()
```
all function between Update() and Publish() are option but you should atleast call one.

Remove from list
```
bool removed  = await client.Anime()
                            .WithId(12345)
                            .RemoveFromList()
```