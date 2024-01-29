using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.Extensions;

public static class UIContextExtensions
{
    public static void OpenAlbum(this UIContext context, TracksDataStore dataStore, SpotifyTrack trackOfAlbum)
    {
        context.AddPage(new AlbumViewModel(context, dataStore, trackOfAlbum));
    }

    public static void OpenTrack(this UIContext context, TracksDataStore dataStore, SpotifyTrack track)
    {
        context.AddPage(new TrackViewModel(context, dataStore, track));
    }
}