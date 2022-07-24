﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalApi.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi.EndPoints;

internal partial class AnimeEndPoint  : IGetAnimeRequest
{
    public async Task<Anime> Find()
    {
        var @params = new Dictionary<string, string>();

        if(Fields.Any())
        {
            @params.Add("fields", string.Join(",", Fields));
        }

        var url = QueryHelpers.AddQueryString($"https://api.myanimelist.net/v2/anime/{Id}", @params);

        return await ParseAnime(url);
    }

    public IUpdateRequest UpdateStatus() => this;
    IGetAnimeRequest IGetAnimeRequest.WithFields(params string[] fields) => WithFields(fields);
}