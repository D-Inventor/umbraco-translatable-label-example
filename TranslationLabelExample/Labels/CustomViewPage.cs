using Umbraco.Cms.Web.Common.Views;

namespace TranslationLabelExample.Labels;

public abstract class CustomViewPage<TModel> : UmbracoViewPage<TModel>
{
    public override void Write(object? value)
        => base.Write(value is Label label ? this.ToText(label) : value);
}