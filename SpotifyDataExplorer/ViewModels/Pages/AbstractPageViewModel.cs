using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Extensions;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Pages;

public abstract class AbstractPageViewModel : AbstractViewModel
{
    public ReactiveCommand<SpotifyTrack, Unit> OpenTrackCmd { get; }
    public ReactiveCommand<SpotifyTrack, Unit> OpenAlbumCmd { get; }
    public ReactiveCommand<SpotifyTrack, Unit> OpenArtistCmd { get; }

    protected AbstractPageViewModel(UIContext context, TracksDataStore dataStore) : base(context)
    {
        OpenTrackCmd = ReactiveCommand.Create<SpotifyTrack>(track => context.OpenTrack(dataStore, track));
        OpenAlbumCmd = ReactiveCommand.Create<SpotifyTrack>(track => context.OpenAlbum(dataStore, track));
        OpenArtistCmd = ReactiveCommand.Create<SpotifyTrack>(track => context.OpenArtist(dataStore, track));
    }
}