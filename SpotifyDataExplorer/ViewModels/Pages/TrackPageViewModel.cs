using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Panels;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class TrackPageViewModel : AbstractPageViewModel
{
    public TrackViewModel TrackViewModel { get; }

    public string TrackName { get; }

    public TrackPageViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context)
    {
        TrackName = spotifyTrack.TrackName;
        TrackViewModel = new TrackViewModel(context, dataStore, spotifyTrack);
    }
}