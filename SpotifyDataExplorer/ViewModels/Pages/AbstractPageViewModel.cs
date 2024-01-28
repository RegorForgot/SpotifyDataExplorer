using System.Reactive;
using ReactiveUI;

namespace SpotifyDataExplorer.ViewModels.Pages;

public abstract class AbstractPageViewModel : AbstractViewModel
{
    protected readonly UIContext Context;
    public ReactiveCommand<Unit, Unit> LastScreenCmd { get; }

    protected AbstractPageViewModel(UIContext context)
    {
        Context = context;
        LastScreenCmd = ReactiveCommand.Create(LastScreen);
    }
    
    private void LastScreen()
    {
        Context.BackPage();
    }
}