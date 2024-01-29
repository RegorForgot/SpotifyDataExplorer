using Autofac;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.ViewModels;

namespace SpotifyDataExplorer.Utilities;

public static class ContainerConfigurator
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new ContainerBuilder();

        builder.RegisterType<UIContext>().AsSelf().SingleInstance();
        builder.RegisterType<MainWindowViewModel>().AsSelf().SingleInstance();
        
        return builder.Build();
    }
}