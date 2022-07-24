namespace MalApi.Tests;

public class MalClientTests
{
    [Fact]
    public async Task Anime_UserList()
    {
        var result = await MalClientWrapper.Instance.Client.Anime().OfUser().Find();
    }
}
