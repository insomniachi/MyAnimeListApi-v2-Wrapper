using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IUpdateAnimeRequest
{
    IUpdateAnimeRequest WithStatus(AnimeStatus status);
    IUpdateAnimeRequest WithScore(Score score);
    IUpdateAnimeRequest WithIsRewatching(bool rewatching);
    IUpdateAnimeRequest WithEpisodesWatched(int episodesWatched);
    IUpdateAnimeRequest WithPriority(Priority priority);
    IUpdateAnimeRequest WithRewatchCount(int rewatchCount);
    IUpdateAnimeRequest WithRewatchValue(Value rewatchValue);
    IUpdateAnimeRequest WithTags(string tags);
    IUpdateAnimeRequest WithComments(string comments);
    Task<UserAnimeStatus> Publish();

}
