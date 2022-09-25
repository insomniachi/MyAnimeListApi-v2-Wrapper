using System;
using System.Threading.Tasks;

namespace MalApi.Interfaces;

public interface IUpdateMangaRequest
{
    IUpdateMangaRequest WithStatus(MangaStatus status);
    IUpdateMangaRequest WithIsRereading(bool isRereading);
    IUpdateMangaRequest WithScore(Score score);
    IUpdateMangaRequest WithVolumesRead(int volumes);
    IUpdateMangaRequest WithChaptersRead(int chapters);
    IUpdateMangaRequest WithPriority(Priority priority);
    IUpdateMangaRequest WithRereadCount(int rereadCount);
    IUpdateMangaRequest WithRereadValue(Value rereadValue);
    IUpdateMangaRequest WithTags(string tags);
    IUpdateMangaRequest WithComments(string comments);
    IUpdateMangaRequest WithStartDate(DateTime startDate);
    IUpdateMangaRequest WithFinishDate(DateTime finishDate);
    Task<UserMangaStatus> Publish();
}
