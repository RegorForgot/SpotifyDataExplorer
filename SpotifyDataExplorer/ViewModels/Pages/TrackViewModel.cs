using System.Linq;
using Avalonia.Controls.Documents;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.Views.Controls;

namespace SpotifyDataExplorer.ViewModels.Pages;

public sealed class TrackViewModel : AbstractPaginatedViewModel<SpotifyTrack>
{
    public TrackViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context, dataStore)
    {
        Pages = dataStore.SpotifyTracks!
            .Where(track => track.ArtistName == spotifyTrack.ArtistName && track.TrackName == spotifyTrack.TrackName)
            .Chunk(20)
            .ToList();

        GoToPage(CurrentPageNum);
    }
}