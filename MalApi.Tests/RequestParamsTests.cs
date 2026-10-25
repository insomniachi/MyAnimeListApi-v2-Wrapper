using System.Net.Http;
using System.Reflection;
using MalApi.EndPoints;

namespace MalApi.Tests;

public class RequestParamsTests
{
    private static IDictionary<string, string> UpdateParams(object endPoint) =>
        (IDictionary<string, string>)endPoint.GetType().GetMethod("GetUpdateParams", BindingFlags.NonPublic | BindingFlags.Instance)!.Invoke(endPoint, null)!;

    [Theory]
    [InlineData(true, "true")]
    [InlineData(false, "false")]
    public void Sends_rewatching_in_lowercase_because_MAL_reads_False_as_true(bool rewatching, string expected)
    {
        var endPoint = new AnimeEndPoint(new HttpClient()) { IsRewatching = rewatching };

        Assert.Equal(expected, UpdateParams(endPoint)["is_rewatching"]);
    }

    [Fact]
    public void Sends_rereading_in_lowercase_and_reread_value_for_manga()
    {
        var endPoint = new MangaEndPoint(new HttpClient()) { IsRereading = false, RereadValue = Value.High };
        var @params = UpdateParams(endPoint);

        Assert.Equal("false", @params["is_rereading"]);
        Assert.True(@params.ContainsKey("reread_value"));
    }

    [Fact]
    public void Leaves_out_what_was_not_set()
    {
        Assert.Empty(UpdateParams(new AnimeEndPoint(new HttpClient())));
    }

    [Fact]
    public void Escapes_query_values()
    {
        var url = Http.WithQuery("https://x/y", new Dictionary<string, string> { ["q"] = "a b&c", ["nsfw"] = false.ToMal() });

        Assert.Equal("https://x/y?q=a%20b%26c&nsfw=false", url);
    }

    [Fact]
    public void Rejects_a_limit_over_the_maximum()
    {
        var request = new AnimeEndPoint(new HttpClient()).WithName("x");

        Assert.Throws<ArgumentException>(() => request.WithLimit(101));
    }
}
