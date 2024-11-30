namespace TranslationTokenExample.Labels;

public abstract record Label()
{
    // 👇 This call is changed so it now returns a StaticLabel.
    public static implicit operator Label(string value)
        => Text(value);

    // 👇 This static factory abstracts the translatable text token,
    // so the rest of the application doesn't need to know that it exists
    public static Label Translate(string key, params object?[] parameters)
        => new TranslatableLabel(key, parameters);

    // 👇 This static factory abstracts the static text implementation
    public static Label Text(string value)
        => new StaticLabel(value);
}

// 👇 We move the value parameter to the static text token
// We also move the ToString override to here, because this is the static
public record StaticLabel(string Value) : Label
{
    public override string ToString() => Value;
}

public record TranslatableLabel(string Key, params object?[] Parameters) : Label;