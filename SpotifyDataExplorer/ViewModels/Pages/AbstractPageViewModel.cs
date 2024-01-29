namespace SpotifyDataExplorer.ViewModels.Pages;

public abstract class AbstractPageViewModel : AbstractViewModel
{
    public UIContext Context { get; }

    protected AbstractPageViewModel(UIContext context)
    {
        Context = context;
    }
}