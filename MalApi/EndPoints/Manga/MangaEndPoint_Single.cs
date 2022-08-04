using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class MangaEndPoint : IGetMangaRequest
{
    public async Task<Manga> Find()
    {
        var @params = new Dictionary<string, string>();

        if (Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/manga/{Id}", @params);

        return await ParseManga(url);
    }

    public async Task<bool> RemoveFromList()
    {
        var url = $"https://api.myanimelist.net/v2/manga/{Id}/my_list_status";
        var response = await _client.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }

    public IUpdateMangaRequest UpdateStatus() => this;

    IGetMangaRequest IGetMangaRequest.WithFields(params string[] fields) => WithFields(fields);
}
