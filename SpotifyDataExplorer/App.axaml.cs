using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SpotifyDataExplorer.Utilities;
using SpotifyDataExplorer.ViewModels;
using SpotifyDataExplorer.Views;

namespace SpotifyDataExplorer;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ILifetimeScope lifetimeScope = ContainerConfigurator.Configure().BeginLifetimeScope();
        MainWindowViewModel mainViewModel = lifetimeScope.Resolve<MainWindowViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}