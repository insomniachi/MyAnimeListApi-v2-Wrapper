using System.ComponentModel;

namespace MalApi;

public enum Value
{
    [Description("Very Low")]
    VeryLow = 0,

    [Description("Low")]
    Low = 1,

    [Description("Medium")]
    Medium = 2,

    [Description("High")]
    High = 3,

    [Description("Very High")]
    VeryHigh = 4
}
