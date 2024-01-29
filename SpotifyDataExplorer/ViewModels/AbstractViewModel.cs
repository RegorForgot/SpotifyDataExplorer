using ReactiveUI;
using SpotifyDataExplorer.Navigation;

namespace SpotifyDataExplorer.ViewModels;

public abstract class AbstractViewModel : ReactiveObject
{
    public UIContext Context { get; set; }
    
    protected AbstractViewModel(UIContext context)
    {
        Context = context;
    }
}