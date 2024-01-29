using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Panels;

public class TrackViewModel : AbstractPaginatedViewModel
{
    private ObservableCollection<SpotifyTrack> _tracks;

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        private set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }

    public TrackViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context, dataStore)
    {
        Pages = dataStore.SpotifyTracks!
            .Where(track => track.ArtistName == spotifyTrack.ArtistName && track.TrackName == spotifyTrack.TrackName)
            .Chunk(20)
            .ToList();

        GoToPage(CurrentPage);
    }

    protected sealed override void GoToPage(int number)
    {
        Tracks = new ObservableCollection<SpotifyTrack>(Pages[CurrentPage]);
        base.GoToPage(number);
    }
}