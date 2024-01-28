using ReactiveUI;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels;

public class UIContext : ReactiveObject
{
    private AbstractPageViewModel _currentViewModel;

    public AbstractPageViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public UIContext() { }
}