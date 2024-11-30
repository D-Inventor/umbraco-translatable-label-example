using TranslationLabelExample.Labels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TranslationLabelExample;

public static class ExampleService
{
    public static LinkDomainModel GetLinkFromContent(this IPublishedContent content)
    {
        var contentToLinkTo = content.Value<IPublishedContent>("linkContent");
        string? labelString = content.Value<string>("linkLabel");
        Label linkLabel = !string.IsNullOrWhiteSpace(labelString)
            ? Label.Text(labelString)
            : Label.Translate("link label default");

        var linkAlt = Label.Translate("link label alttext", contentToLinkTo.Name);

        return new LinkDomainModel(
            contentToLinkTo.Url(),
            linkLabel,
            linkAlt);
    }
}