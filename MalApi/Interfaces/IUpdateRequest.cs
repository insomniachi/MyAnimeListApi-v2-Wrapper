using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IUpdateRequest
{
    IUpdateRequest WithStatus(AnimeStatus status);
    IUpdateRequest WithScore(Score score);
    IUpdateRequest WithIsRewatching(bool rewatching);
    IUpdateRequest WithEpisodesWatched(int episodesWatched);
    IUpdateRequest WithPriority(Priority priority);
    IUpdateRequest WithRewatchCount(int rewatchCount);
    IUpdateRequest WithRewatchValue(RewatchValue rewatchValue);
    IUpdateRequest WithTags(string tags);
    IUpdateRequest WithComments(string comments);
    Task<UserAnimeStatus> Publish();

}