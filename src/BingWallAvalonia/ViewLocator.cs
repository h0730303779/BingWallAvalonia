using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Templates;
using BingWallAvalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BingWallAvalonia
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }

        public static Window ResolveViewFromViewModel<T>(T vm) where T : ViewModelBase
        {
            var name = vm.GetType().AssemblyQualifiedName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);
            //return type != null ? (Window)Activator.CreateInstance(type)! : null;
            if (type != null)
            {
                return (Window)Activator.CreateInstance(type)!;
            }
            else
            {
                return null;
            }

        }

        public static Window Windows => (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;




    }
}