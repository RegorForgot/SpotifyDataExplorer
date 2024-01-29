using SpotifyDataExplorer.Navigation;

namespace SpotifyDataExplorer.ViewModels.Pages;

public abstract class AbstractPageViewModel : AbstractViewModel
{
    protected AbstractPageViewModel(UIContext context) : base(context) { }
}