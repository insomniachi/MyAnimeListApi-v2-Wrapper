using System.ComponentModel;

namespace MalApi;

public enum AiringStatus
{
    [Description("Finished Airing")]
    FinishedAiring,

    [Description("Currently Airing")]
    CurrentlyAiring,

    [Description("Not Yet Aired")]
    NotYetAired
}
