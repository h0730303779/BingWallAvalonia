using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BingWallAvalonia.ViewModels;

namespace BingWallAvalonia.Views;

public partial class Setting : Window
{
    public Setting()
    {
        InitializeComponent();
        DataContext = new SettingViewModel();
    }
}