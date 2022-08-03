using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class AnimeSourceConverter : JsonConverter<AnimeSource>
{
    public override AnimeSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();

        return text switch
        {
            "other" => AnimeSource.Other,
            "original" => AnimeSource.Original,
            "manga" => AnimeSource.Manga,
            "4_koma_manga" => AnimeSource.KomaManga,
            "web_manga" => AnimeSource.WebManga,
            "digital_manga" => AnimeSource.DigitalManga,
            "novel" => AnimeSource.Novel,
            "light_novel" => AnimeSource.LightNovel,
            "visual_novel" => AnimeSource.VisualNovel,
            "game" => AnimeSource.Game,
            "card_game" => AnimeSource.CardGame,
            "book" => AnimeSource.Book,
            "picture_book" => AnimeSource.PictureBook,
            "radio" => AnimeSource.Radio,
            "music" => AnimeSource.Music,
            _ => AnimeSource.Other,
        };
    }

    public override void Write(Utf8JsonWriter writer, AnimeSource value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case AnimeSource.Other:
                writer.WriteStringValue("other");
                break;
            case AnimeSource.Original:
                writer.WriteStringValue("original");
                break;
            case AnimeSource.Manga:
                writer.WriteStringValue("manga");
                break;
            case AnimeSource.KomaManga:
                writer.WriteStringValue("4_koma_manga");
                break;
            case AnimeSource.WebManga:
                writer.WriteStringValue("web_manga");
                break;
            case AnimeSource.DigitalManga:
                writer.WriteStringValue("digital_manga");
                break;
            case AnimeSource.Novel:
                writer.WriteStringValue("novel");
                break;
            case AnimeSource.LightNovel:
                writer.WriteStringValue("light_novel");
                break;
            case AnimeSource.VisualNovel:
                writer.WriteStringValue("visual_novel");
                break;
            case AnimeSource.Game:
                writer.WriteStringValue("game");
                break;
            case AnimeSource.CardGame:
                writer.WriteStringValue("card_game");
                break;
            case AnimeSource.Book:
                writer.WriteStringValue("book");
                break;
            case AnimeSource.PictureBook:
                writer.WriteStringValue("picture_book");
                break;
            case AnimeSource.Radio:
                writer.WriteStringValue("radio");
                break;
            case AnimeSource.Music:
                writer.WriteStringValue("music");
                break;
        }
    }
}