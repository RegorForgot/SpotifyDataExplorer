using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels.Panels;

public class TrackViewModel : AbstractPaginatedViewModel
{
    private ObservableCollection<SpotifyTrack> _tracks;

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        private set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }

    public ReactiveCommand<SpotifyTrack, Unit> OpenAlbumCmd { get; }

    public TrackViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context, dataStore)
    {
        OpenAlbumCmd = ReactiveCommand.Create<SpotifyTrack>(OpenAlbum);
        
        Pages = dataStore.SpotifyTracks!
            .Where(track => track.ArtistName == spotifyTrack.ArtistName && track.TrackName == spotifyTrack.TrackName)
            .Chunk(20)
            .ToList();

        GoToPage(CurrentPage);
    }
    
    private void OpenAlbum(SpotifyTrack track)
    {
        Context.AddPage(new AlbumPageViewModel(Context, DataStore, track));
    }

    protected sealed override void GoToPage(int number)
    {
        Tracks = new ObservableCollection<SpotifyTrack>(Pages[CurrentPage]);
        base.GoToPage(number);
    }
}