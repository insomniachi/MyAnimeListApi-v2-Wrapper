using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MalApi;

internal static class Http
{
    // bool.ToString() is "False", which MAL reads as true in form bodies.
    public static string ToMal(this bool value) => value ? "true" : "false";

    public static string WithQuery(string url, IEnumerable<KeyValuePair<string, string>> query) =>
        url + "?" + string.Join("&", query.Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value ?? "")}"));

    public static async Task<T> GetJson<T>(this HttpClient client, string url)
    {
        await using var stream = await client.GetStreamAsync(url);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }

    /// <summary>Reads the body as JSON, throwing <see cref="HttpRequestException"/> (with MAL's error body) if the request failed.</summary>
    public static async Task<T> ReadJson<T>(this HttpResponseMessage response)
    {
        using (response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"MyAnimeList returned {(int)response.StatusCode} {response.ReasonPhrase}: {body}", null, response.StatusCode);
            }

            await using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
