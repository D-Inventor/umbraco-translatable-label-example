using System.Diagnostics;
using Umbraco.Cms.Web.Common.Views;

namespace TranslationLabelExample.Labels;

public static class LabelExtensions
{
    public static string? ToText<TModel>(this UmbracoViewPage<TModel> page, Label label)
        => label switch
        {
            // 👇 Check which type of label we've found and convert it to text accordingly
            TranslatableLabel translatableLabel => page.Translate(translatableLabel),
            StaticLabel staticLabel => staticLabel.Value,
            _ => throw new UnreachableException()
        };

    private static string? Translate<TModel>(this UmbracoViewPage<TModel> page, TranslatableLabel label)
        => (page.Umbraco.GetDictionaryValue(label.Key)?.Trim(), label.Parameters) switch
        {
            (null or "", _) => null,
            (var text, null or []) => text,
            (var text, var parameters) => string.Format(text, parameters)
        };
}