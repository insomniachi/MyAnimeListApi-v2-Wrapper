using System;

namespace MalApi.Tests;

public class MalClientTests
{
    [Fact]
    public async Task Anime_UserList()
    {
        var client = MalClientWrapper.Instance.Client;
        client.SetClientId("748da32a6defdd448c1f47d60b4bbe69");
        var result = await client.Anime().OfUser("Athul_Raj").WithStatus(AnimeStatus.Watching).IncludeNsfw().Find();
    }
}
