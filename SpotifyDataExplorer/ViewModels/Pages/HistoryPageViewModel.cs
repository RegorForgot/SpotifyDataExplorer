using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Panels;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class HistoryPageViewModel : AbstractPageViewModel
{
    public HistoryViewModel HistoryViewModel { get; }

    public HistoryPageViewModel(UIContext context, TracksDataStore dataStore) : base(context)
    {
        HistoryViewModel = new HistoryViewModel(context, dataStore);
    }
}