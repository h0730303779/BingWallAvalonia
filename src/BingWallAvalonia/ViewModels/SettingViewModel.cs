using BingWallAvalonia.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallAvalonia.ViewModels
{
    public partial class SettingViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _PathDir;


        public SettingViewModel()
        {
            ConfigService configService = new ConfigService();
            PathDir = configService.GetProperty("filedir");
        }
    }
}
