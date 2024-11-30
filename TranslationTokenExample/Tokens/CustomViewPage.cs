using Umbraco.Cms.Web.Common.Views;

namespace TranslationTokenExample.Labels;

public abstract class CustomViewPage<TModel> : UmbracoViewPage<TModel>
{
    public override void Write(object? value)
        => base.Write(value is Label token ? this.ToText(token) : value);
}