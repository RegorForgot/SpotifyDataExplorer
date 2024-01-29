using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels.Panels;

public sealed class HistoryViewModel : AbstractPaginatedViewModel
{
    private ObservableCollection<SpotifyTrack> _tracks;

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        private set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }

    public ReactiveCommand<SpotifyTrack, Unit> OpenTrackCmd { get; }
    public ReactiveCommand<SpotifyTrack, Unit> OpenAlbumCmd { get; }


    public HistoryViewModel(UIContext context, TracksDataStore dataStore) : base(context, dataStore)
    {
        OpenTrackCmd = ReactiveCommand.Create<SpotifyTrack>(OpenTrack);
        OpenAlbumCmd = ReactiveCommand.Create<SpotifyTrack>(OpenAlbum);

        if (dataStore.SpotifyTracks != null)
        {
            Pages = dataStore.SpotifyTracks.Chunk(50).ToList();
        }

        GoToPage(CurrentPage);
    }

    private void OpenTrack(SpotifyTrack track)
    {
        Context.AddPage(new TrackPageViewModel(Context, DataStore, track));
    }
    
    private void OpenAlbum(SpotifyTrack track)
    {
        Context.AddPage(new AlbumPageViewModel(Context, DataStore, track));
    }

    protected override void GoToPage(int number)
    {
        Tracks = new ObservableCollection<SpotifyTrack>(Pages[CurrentPage]);
        base.GoToPage(number);
    }
}