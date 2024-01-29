using System.Linq;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Pages;

public sealed class HistoryViewModel : AbstractPaginatedViewModel<SpotifyTrack>
{
    public HistoryViewModel(UIContext context, TracksDataStore dataStore) : base(context, dataStore)
    {
        if (dataStore.SpotifyTracks != null)
        {
            Pages = dataStore.SpotifyTracks.Chunk(50).ToList();
        }
                
        GoToPage(CurrentPageNum);
    }
}