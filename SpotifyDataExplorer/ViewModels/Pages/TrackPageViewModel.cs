using System.Linq;
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
        
        var trackPages =
            dataStore.SpotifyTracks!
                .Where(track => track.ArtistName == spotifyTrack.ArtistName)
                .Where(track => track.TrackName == spotifyTrack.TrackName)
                .Chunk(20)
                .ToList();

        TrackViewModel = new TrackViewModel(context, dataStore, trackPages);
    }

}