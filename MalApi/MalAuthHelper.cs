using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MalApi;

public static class MalAuthHelper
{
    private const string AuthUrl = "https://myanimelist.net/v1/oauth2/";
    private static readonly HttpClient _client = new();

    // MAL only supports the "plain" PKCE method, so the challenge is the verifier itself.
    private static readonly string _codeVerifier =
        RandomNumberGenerator.GetString("AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789-._~", 128);

    public static string GetAuthUrl(string clientId) => Http.WithQuery(AuthUrl + "authorize", new Dictionary<string, string>
    {
        ["response_type"] = "code",
        ["client_id"] = clientId,
        ["code_challenge"] = _codeVerifier,
        ["state"] = "abc"
    });

    /// <summary>Exchanges the sign-in code for a token. Throws <see cref="HttpRequestException"/> if MAL rejects it.</summary>
    public static Task<OAuthToken> DoAuth(string clientId, string code) => RequestToken(new Dictionary<string, string>
    {
        ["client_id"] = clientId,
        ["code"] = code,
        ["code_verifier"] = _codeVerifier,
        ["grant_type"] = "authorization_code"
    });

    /// <summary>Gets a new token. Throws <see cref="HttpRequestException"/> if MAL rejects it, so a bad response never replaces a saved token.</summary>
    public static Task<OAuthToken> RefreshToken(string clientId, string refreshToken) => RequestToken(new Dictionary<string, string>
    {
        ["client_id"] = clientId,
        ["refresh_token"] = refreshToken,
        ["grant_type"] = "refresh_token"
    });

    private static async Task<OAuthToken> RequestToken(Dictionary<string, string> form)
    {
        using var content = new FormUrlEncodedContent(form);
        var token = await (await _client.PostAsync(AuthUrl + "token", content).ConfigureAwait(false)).ReadJson<OAuthToken>().ConfigureAwait(false);
        token.CreateAt = DateTime.UtcNow;
        return token;
    }
}

public class OAuthToken
{
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreateAt { get; set; }

    [JsonIgnore]
    public bool IsExpired => (DateTime.UtcNow - CreateAt).Days >= 28;
}
