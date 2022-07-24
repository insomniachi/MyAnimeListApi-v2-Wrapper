using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IUpdateRequest
{
    IUpdateRequest WithStatus(AnimeStatus status);
    IUpdateRequest WithScore(int score);
    IUpdateRequest WithIsRewatching(bool rewatching);
    IUpdateRequest WithEpisodesWatched(int episodesWatched);
    IUpdateRequest WithPriority(int priority);
    IUpdateRequest WithRewatchCount(int rewatchCount);
    IUpdateRequest WithRewatchValue(int rewatchValue);
    IUpdateRequest WithTags(string tags);
    IUpdateRequest WithComments(string comments);
    Task<UserAnimeStatus> Publish();

}