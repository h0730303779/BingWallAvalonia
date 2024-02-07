using Avalonia.Markup.Xaml;
using AvaloniaStyles = Avalonia.Styling.Styles;

namespace BingWallAvalonia.Assets.Themes;

public class DarkTheme : AvaloniaStyles
{
    public DarkTheme() => AvaloniaXamlLoader.Load(this);
}