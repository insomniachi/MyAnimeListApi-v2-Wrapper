using System.ComponentModel;

namespace MalApi;

public enum Score
{
    [Description("Select score")]
    Unscored = 0,

    [Description("Appalling")]
    Appalling = 1,

    [Description("Horrible")]
    Horrible = 2,

    [Description("Very Bad")]
    VeryBad = 3,

    [Description("Bad")]
    Bad = 4,

    [Description("Average")]
    Average = 5,

    [Description("Fine")]
    Fine = 6,

    [Description("Good")]
    Good = 7,

    [Description("Very Good")]
    VeryGood = 8,

    [Description("Great")]
    Great = 9,

    [Description("Masterpiece")]
    Masterpiece = 10
}
