using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Panels;

public sealed class HistoryViewModel : AbstractPaginatedViewModel
{
    private ObservableCollection<SpotifyTrack> _tracks;

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        private set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }
    
    public HistoryViewModel(UIContext context, TracksDataStore dataStore) : base(context, dataStore)
    {

        if (dataStore.SpotifyTracks != null)
        {
            Pages = dataStore.SpotifyTracks.Chunk(50).ToList();
        }

        GoToPage(CurrentPage);
    }

    protected override void GoToPage(int number)
    {
        Tracks = new ObservableCollection<SpotifyTrack>(Pages[CurrentPage]);
        base.GoToPage(number);
    }
}