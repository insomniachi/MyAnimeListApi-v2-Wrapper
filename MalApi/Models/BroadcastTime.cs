using System;
using System.Text.Json.Serialization;
using MalApi.JsonConverters;

namespace MalApi
{
    public class BroadcastTime
    {
        [JsonPropertyName("day_of_the_week")]
        [JsonConverter(typeof(DayOfWeekConverter))]
        public DayOfWeek? DayOfWeek { get; set; }

        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
    }
}
