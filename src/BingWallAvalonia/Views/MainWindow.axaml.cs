using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BingWallAvalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Screens.Primary
            //this.Get<Button>("BtnDownloadImage").Click += OnDownloadImage; ;
        }

        //private async void OnDownloadImage(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new();
        //    await ofd.ShowAsync(this);

            
        //}

        //private void InitializeComponent()
        //{
        //    AvaloniaXamlLoader.Load(this);
        //}
 
    }
}