using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class RelationTypeConverter : JsonConverter<RelationType>
{
    public override RelationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();

        return text switch
        {
            "sequel" => RelationType.Sequel,
            "prequel" => RelationType.Prequel,
            "alternative_setting" => RelationType.AlternativeSetting,
            "alternative_version" => RelationType.AlternativeVersion,
            "side_story" => RelationType.SideStory,
            "parent_story" => RelationType.ParentStory,
            "summary" => RelationType.Summary,
            "full_story" => RelationType.Summary,
            _ => RelationType.Summary // Will this ever happen ? can i throw exception ?
        };
    }

    public override void Write(Utf8JsonWriter writer, RelationType value, JsonSerializerOptions options)
    {
        switch(value)
        {
            case RelationType.Sequel:
                writer.WriteStringValue("sequel");
                break;
            case RelationType.Prequel:
                writer.WriteStringValue("prequel");
                break;
            case RelationType.AlternativeSetting:
                writer.WriteStringValue("alternative_setting");
                break;
            case RelationType.AlternativeVersion:
                writer.WriteStringValue("alternative_version");
                break;
            case RelationType.SideStory:
                writer.WriteStringValue("side_story");
                break;
            case RelationType.ParentStory:
                writer.WriteStringValue("parent_story");
                break;
            case RelationType.Summary:
                writer.WriteStringValue("summary");
                break;
            case RelationType.FullStory:
                writer.WriteStringValue("full_story");
                break;
        }
    }
}
