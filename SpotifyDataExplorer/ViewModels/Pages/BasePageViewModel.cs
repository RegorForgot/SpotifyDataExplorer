using System.Reactive;
using ReactiveUI;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class BasePageViewModel : AbstractPageViewModel
{
    public ReactiveCommand<Unit, Unit> LastScreenCmd { get; }
    
    public BasePageViewModel(UIContext context) : base(context)
    {
        LastScreenCmd = ReactiveCommand.Create(LastScreen);
    }
    
    private void LastScreen()
    {
        Context.BackPage();
    }
}