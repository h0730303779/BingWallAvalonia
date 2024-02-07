using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using BingWallAvalonia.Models;
using BingWallAvalonia.Services;
using BingWallAvalonia.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace BingWallAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        private ImagesModel imagesModel;
        private ImageModel selectedimagesModel;
        private int selectedNum = 0;

        [ObservableProperty]
        private string _SelectedImageText;

        [ObservableProperty]
        private double _Height;


        [ObservableProperty]
        private Bitmap _SelectedImage;

        [ObservableProperty]
        private ObservableCollection<ImageModel> _ItemsLeft;

        [ObservableProperty]
        private ObservableCollection<ImageModel> _ItemsRight;

        private List<ImageModel> ItemsAll;

        public MainWindowViewModel()
        {
            try
            {
                var main = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime);
                //var screens = screen = AvaloniaLocator.Current.GetService<IScreen>();
                //var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
                //var Height =ViewLocator.Windows.Height;


                Init(); 
            }
            catch (System.Exception err)
            {

                throw;
            }

        }

        [RelayCommand]
        public void PrevImage()
        {
            ChanageImageByNum(--selectedNum);
        }
        [RelayCommand]
        public void NextImage()
        {
            ChanageImageByNum(++selectedNum);
        }

        private void ChanageImageByNum(int num)
        {
            if (num > ItemsAll.Count || num < 1)
            {
                return;
            }
            var thatItem = ItemsAll.Find(t => t.Number == num);
            ArgumentNullException.ThrowIfNull(num,nameof(num) + "not find item");
            ChanageImage(thatItem);

        }

        [RelayCommand]
        public void OnBtnChange(ImageModel model)
        { 

            ChanageImage(model);
        }

        private void Init()
        {
            string bingImage = "https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=10";
            HttpClient webClient = new HttpClient();
            string imagesModelJson = webClient.GetStringAsync(bingImage).Result;
            imagesModel = JsonSerializer.Deserialize<ImagesModel>(imagesModelJson);
            ItemsAll = imagesModel.Images;
            for (int i = ItemsAll.Count; 0 < i; i--)
            {
                var _tmpitem = ItemsAll[i - 1];
                _tmpitem.Number = ItemsAll.Count - (i - 1);
            }
            ChanageImage(ItemsAll[0]);
        }

        private void ChanageImage(ImageModel imageModel)
        {
            selectedimagesModel = imageModel;
            selectedNum = imageModel.Number;
            var url = imageModel.Url;
            var imgurl = "https://www.bing.com" + url;
            HttpClient webClient = new HttpClient();
            var bytes = webClient.GetByteArrayAsync(imgurl).Result;
            MemoryStream sStream = new MemoryStream(bytes);
            SelectedImage = new Bitmap(sStream);
            SelectedImageText = imageModel.Title;
            ItemsLeft = new ObservableCollection<ImageModel>();
            ItemsRight = new ObservableCollection<ImageModel>();
            for (int i = ItemsAll.Count - imageModel.Number + 1; i < ItemsAll.Count; i++)
            {
                var _tmpitem = ItemsAll[i];
                ItemsLeft.Insert(0, _tmpitem);
            }
            for (int i = 0; i < ItemsAll.Count - imageModel.Number; i++)
            {
                var _tmpitem = ItemsAll[i];
                ItemsRight.Insert(0, ItemsAll[i]);
            }
        }

        [RelayCommand]
        async void OnDownloadImage()
        {

            SaveFileDialog saveFileDialog = new() {
                Title = "保存位置",
                InitialFileName = selectedimagesModel.Title + ".jpg"
            };
            var wenjianlj = await saveFileDialog.ShowAsync(ViewLocator.Windows);
            
            if (wenjianlj != null)
            {
                SelectedImage.Save(wenjianlj);
                ConfigService.Instance.SetProperty("filedir", wenjianlj);
            }
        }

        [RelayCommand]
        async void OnShowSetting()
        {
            Setting settingDialog = new()
            {
                Height = 500,
                Width = 680
            };
            await settingDialog.ShowDialog(ViewLocator.Windows);

        }


        List<FileDialogFilter> GetFilters()
        {
 
            return new List<FileDialogFilter>
                            {
                                new FileDialogFilter
                                {
                                    Name = "Text files (.txt)", Extensions = new List<string> {"txt"}
                                },
                                new FileDialogFilter
                                {
                                    Name = "All files",
                                    Extensions = new List<string> {"*"}
                                }
                            };
        }

    }
}