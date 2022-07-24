using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MalApi.EndPoints;
using MalApi.Interfaces;
using MalApi.Requests;
using Microsoft.AspNetCore.WebUtilities;

namespace MalApi
{
    public class MalClient : IMalClient
    {
        public MalClient(string accessToken)
        {
            HttpRequest.AccessToken = accessToken;
            Http.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }

        public IAnimeEndPoint Anime() => new AnimeEndPoint();

        public async Task<MalUser> User()
        {
            var url = QueryHelpers.AddQueryString("https://api.myanimelist.net/v2/users/@me", new Dictionary<string, string>
            {
                ["fields"] = "anime_statistics"
            });

            var stream = await Http.Client.GetStreamAsync(url);
            return await JsonSerializer.DeserializeAsync<MalUser>(stream);
        }


        public async Task<List<ForumCategory>> GetForumBoardsAsync()
        {
            var request = new GetForumBoardsRequest();

            return await request.GetAsync();
        }

        public async Task<ForumTopicData> GetForumTopicDetailsAsync(int id)
        {
            var request = new GetForumTopicDetailRequest(id);

            return await request.GetAsync();
        }

        public async Task<List<ForumTopicDetails>> GetForumTopicsAsync(string querry, int boardId =1, int subBoardId = -1 , string topicUser = "", string user = "")
        {
            var request = new GetForumTopicsRequest(querry, boardId, subBoardId, topicUser, user);

            return await request.GetAsync();
        }

        public async Task<Manga> GetMangaAsync(int id)
        {
            var request = new GetMangaRequest(id);

            return await request.GetAsync();
        }

        public async Task<List<RankedManga>> GetRankedMangaAsync(MangaRankingType type = MangaRankingType.All, int count = 25)
        {
            var request = new GetRankedMangaRequest(type, count);

            return await request.GetAsync();
        }

        public async Task<UserMangaStatus> UpdateUserMangaStatusAsync(int id, MangaStatus status = MangaStatus.None, bool? isReReading = null, int score = -1, int volumesRead = -1,
                        int chaptersRead = -1, int priority = -1, int reReadCount = -1, int reReadValue = -1, string tags = "", string comments ="")
        {
            var request = new UpdateMangaUserStatusRequest(id, status, isReReading, score, volumesRead, chaptersRead, priority, reReadCount, reReadValue, tags, comments);

            return await request.PutAsync();
        }

        public async Task<bool> DeleteUserMangaAsync(int id)
        {
            var request = new DeleteUserMangaRequest(id);

            return await request.DeleteAsync();
        }

        public async Task<List<Manga>> GetUserMangaAsync(MangaStatus status = MangaStatus.None)
        {
            var request = new GetUserMangaListRequest(status);

            return await request.GetAsync();
        }
    }
}
