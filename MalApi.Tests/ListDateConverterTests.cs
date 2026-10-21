using System.Text.Json;

namespace MalApi.Tests;

public class ListDateConverterTests
{
    [Theory]
    [InlineData("2020-05-14", 2020, 5, 14)]
    [InlineData("2020-05", 1, 1, 1)]
    [InlineData("2020", 1, 1, 1)]
    public void Reads_full_dates_and_partial_ones_as_default(string date, int year, int month, int day)
    {
        var status = JsonSerializer.Deserialize<UserAnimeStatus>($"{{\"start_date\":\"{date}\",\"finish_date\":\"{date}\"}}");

        Assert.Equal(new DateTime(year, month, day), status.StartDate);
        Assert.Equal(new DateTime(year, month, day), status.FinishDate);
    }
}
