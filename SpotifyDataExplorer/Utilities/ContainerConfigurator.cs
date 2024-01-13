using System.Reflection;
using Autofac;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.Utilities;

public static class ContainerConfigurator
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new ContainerBuilder();

        builder.RegisterType<MainWindowViewModel>().AsSelf().SingleInstance();

        builder.RegisterAssemblyTypes(Assembly.Load(nameof(SpotifyDataExplorer)))
            .Where(t => t.Namespace.Contains("ViewModels.Pages"))
            .AsSelf()
            .As<AbstractPageViewModel>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterType<TracksDataStore>().AsSelf().SingleInstance();
        
        return builder.Build();
    }
}