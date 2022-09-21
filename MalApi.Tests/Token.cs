using System.Text.Json;
using MalApi.Interfaces;

namespace MalApi.Tests;

public class MalClientWrapper
{
    private static MalClientWrapper _wrapper;
    public static MalClientWrapper Instance => _wrapper ?? new();
    
    public OAuthToken OAuthToken { get; set; }
    public IMalClient Client { get; }

    const string FileName = "token.json";

    public MalClientWrapper()
    {
        var filePath = Path.Combine(Path.GetDirectoryName(typeof(MalClientWrapper).Assembly.Location), FileName);
        var text = File.ReadAllText(filePath);
        OAuthToken = JsonSerializer.Deserialize<OAuthToken>(text);

        if(OAuthToken.IsExpired)
        {
            OAuthToken = MalAuthHelper.RefreshToken("748da32a6defdd448c1f47d60b4bbe69", OAuthToken.RefreshToken).Result;
            File.WriteAllText(filePath, JsonSerializer.Serialize(OAuthToken));
        }

        Client = new MalClient();
        Client.SetClientId("748da32a6defdd448c1f47d60b4bbe69");
        Client.SetAccessToken(OAuthToken.AccessToken);
    }
}
