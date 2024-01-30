using System.Collections.ObjectModel;
using System.Linq;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.DTOs;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class ArtistViewModel : AbstractPageViewModel
{
    public ObservableCollection<AlbumDto> Albums { get; }
    public ObservableCollection<AlbumDto> FullAlbums { get; }

    public ObservableCollection<TrackDto> Tracks { get; }
    public ObservableCollection<TrackDto> FullTracks { get; }

    public ArtistViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack track) : base(context, dataStore)
    {
        FullAlbums = new ObservableCollection<AlbumDto>(
            dataStore.SpotifyTracks!.AsQueryable()
                .Where(spotifyTrack => spotifyTrack.ArtistName == track.ArtistName)
                .GroupBy(spotifyTrack => spotifyTrack.AlbumName)
                .Select(tracks => new AlbumDto(track, tracks.Count()))
                .OrderByDescending(dto => dto.Count)
        );
        Albums = new ObservableCollection<AlbumDto>(FullAlbums.Take(10));

        FullTracks = new ObservableCollection<TrackDto>(
            dataStore.SpotifyTracks!.AsQueryable()
                .Where(spotifyTrack => spotifyTrack.ArtistName == track.ArtistName)
                .GroupBy(spotifyTrack => spotifyTrack.TrackName)
                .Select(tracks => new TrackDto(track, tracks.Count()))
                .OrderByDescending(dto => dto.Count)
        );
        Tracks = new ObservableCollection<TrackDto>(FullTracks.Take(10));
    }
}