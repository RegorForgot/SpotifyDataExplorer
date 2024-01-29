using System.Collections.ObjectModel;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.DTOs;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class ArtistViewModel : AbstractPageViewModel
{
    public ObservableCollection<AlbumDto> Albums { get; }
    public ObservableCollection<TrackDto> Tracks { get; }

    public ArtistViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack track) : base(context, dataStore) { }
}