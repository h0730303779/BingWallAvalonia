using Avalonia.Markup.Xaml;
using AvaloniaStyles = Avalonia.Styling.Styles;

namespace BingWallAvalonia.Assets.Themes;

public class LightTheme : AvaloniaStyles
{
    public LightTheme() => AvaloniaXamlLoader.Load(this);
}