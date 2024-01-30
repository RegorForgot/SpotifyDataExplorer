using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.DTOs;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class ArtistViewModel : AbstractPageViewModel
{
    public string ArtistName { get; }

    public int PlayCount { get; }
    public int AlbumCount { get; }
    public int TrackCount { get; }

    public ObservableCollection<AlbumDto> Albums { get; }
    private List<AlbumDto> FullAlbums { get; }

    public ObservableCollection<TrackDto> Tracks { get; }
    private List<TrackDto> FullTracks { get; }

    public ArtistViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack track) : base(context, dataStore)
    {
        var artistPlays = dataStore.SpotifyTracks!
            .AsQueryable()
            .Where(spotifyTrack => spotifyTrack.ArtistName == track.ArtistName);

        FullAlbums = artistPlays
            .GroupBy(spotifyTrack => spotifyTrack.AlbumName)
            .Select(tracks => new AlbumDto(tracks.First(), tracks.Count()))
            .OrderByDescending(dto => dto.Count)
            .ToList();
        Albums = new ObservableCollection<AlbumDto>(FullAlbums.Take(10));

        FullTracks = artistPlays
            .GroupBy(spotifyTrack => spotifyTrack.TrackName)
            .Select(tracks => new TrackDto(tracks.First(), tracks.Count()))
            .OrderByDescending(dto => dto.Count)
            .ToList();
        Tracks = new ObservableCollection<TrackDto>(FullTracks.Take(10));

        ArtistName = track.ArtistName;
        AlbumCount = FullAlbums.Count;
        TrackCount = FullTracks.Count;
        PlayCount = artistPlays.Count();
    }
}