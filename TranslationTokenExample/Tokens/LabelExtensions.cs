using System.Diagnostics;
using Umbraco.Cms.Web.Common.Views;

namespace TranslationTokenExample.Labels;

public static class LabelExtensions
{
    public static string? ToText<TModel>(this UmbracoViewPage<TModel> page, Label token)
        => token switch
        {
            // 👇 Check which type of token we've found and convert it to text accordingly
            TranslatableLabel translatableToken => page.Translate(translatableToken),
            StaticLabel staticToken => staticToken.Value,
            _ => throw new UnreachableException()
        };

    private static string? Translate<TModel>(this UmbracoViewPage<TModel> page, TranslatableLabel token)
        => (page.Umbraco.GetDictionaryValue(token.Key)?.Trim(), token.Parameters) switch
        {
            (null or "", _) => null,
            (var text, null or []) => text,
            (var text, var parameters) => string.Format(text, parameters)
        };
}