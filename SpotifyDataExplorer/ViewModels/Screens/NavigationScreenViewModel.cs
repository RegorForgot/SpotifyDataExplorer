using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Navigation;

namespace SpotifyDataExplorer.ViewModels.Screens;

public class NavigationScreenViewModel : AbstractScreenViewModel
{
    public ReactiveCommand<Unit, Unit> LastScreenCmd { get; }
    public ReactiveCommand<Unit, Unit> BackToStartCmd { get; }

    public NavigationScreenViewModel(UIContext context) : base(context)
    {
        LastScreenCmd = ReactiveCommand.Create(LastScreen);
        BackToStartCmd = ReactiveCommand.Create(BackToStart);
    }

    private void BackToStart()
    {
        Context.CurrentScreen = new StartScreenViewModel(Context);
        Context.RemoveAllPages();
    }

    private void LastScreen()
    {
        Context.BackPage();
    }
}