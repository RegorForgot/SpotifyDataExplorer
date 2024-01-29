using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Panels;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class AlbumPageViewModel : AbstractPageViewModel
{
    public AlbumViewModel AlbumViewModel { get; }
    public string AlbumName { get; }
    
    public AlbumPageViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context)
    {
        AlbumName = spotifyTrack.AlbumName;
        AlbumViewModel = new AlbumViewModel(context, dataStore, spotifyTrack);
    }
}