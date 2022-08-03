using System.Linq.Expressions;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MalApi;

public class ExpressionsHelper
{
    public static string GetJsonPropertyNames<T>(Expression<Func<Anime, T>> expression)
    {
        var memberExpression = expression.Body as MemberExpression;
        return GetPropertyName(memberExpression);
    }

    public static string GetJsonPropertyNames<T>(Expression<Func<Manga, T>> expression)
    {
        var memberExpression = expression.Body as MemberExpression;
        return GetPropertyName(memberExpression);
    }

    private static string GetPropertyName(MemberExpression memberExpression)
    {

        var propinfo = memberExpression.Member as PropertyInfo;
        return propinfo.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? $"{propinfo.Name[..1].ToLower()}{propinfo.Name[1..]}";
    }
}