using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels;

public class MainWindowViewModel : AbstractViewModel
{
    public UIContext Context { get; }

    public MainWindowViewModel(UIContext context)
    {
        Context = context;
        Context.CurrentWindow = new StartPageViewModel(Context);
    }
}