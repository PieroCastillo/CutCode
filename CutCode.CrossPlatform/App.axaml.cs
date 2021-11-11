using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CutCode.CrossPlatform.Interfaces;
using CutCode.CrossPlatform.ViewModels;
using CutCode.CrossPlatform.Views;
using CutCode.DataBase;
using Splat;

namespace CutCode.CrossPlatform
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                AvaloniaLocator.CurrentMutable.BindToSelfSingleton<ThemeService>();
                AvaloniaLocator.CurrentMutable.BindToSelfSingleton<DataBaseManager>();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}