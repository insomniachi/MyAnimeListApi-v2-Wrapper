namespace MalApi.Tests;

public class MalClientTests
{
    [Fact]
    public async Task Anime_UserList()
    {
        var client = MalClientWrapper.Instance.Client;
        var result = await client.Anime().OfUser().WithStatus(AnimeStatus.Watching).IncludeNsfw()
                                                             .WithField(x => x.UserStatus).Find();
    }
}
