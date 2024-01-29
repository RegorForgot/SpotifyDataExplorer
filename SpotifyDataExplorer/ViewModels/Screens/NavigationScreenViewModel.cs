using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Navigation;

namespace SpotifyDataExplorer.ViewModels.Screens;

public class NavigationScreenViewModel : AbstractScreenViewModel
{
    public ReactiveCommand<Unit, Unit> LastScreenCmd { get; }

    public NavigationScreenViewModel(UIContext context) : base(context)
    {
        LastScreenCmd = ReactiveCommand.Create(LastScreen);
    }

    private void LastScreen()
    {
        Context.BackPage();
    }
}