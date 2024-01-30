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

    public IEnumerable<AlbumDto> Albums { get; }
    public IEnumerable<TrackDto> Tracks { get; }

    public ArtistViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack track) : base(context, dataStore)
    {
        var artistPlays = dataStore.SpotifyTracks!
            .AsQueryable()
            .Where(spotifyTrack => spotifyTrack.ArtistName == track.ArtistName);

        var albums = artistPlays
            .GroupBy(spotifyTrack => spotifyTrack.AlbumName);

        Albums = albums
            .Select(tracks => new AlbumDto(tracks.First(), tracks.Count()))
            .OrderByDescending(dto => dto.Count)
            .Take(10);

        var tracks = artistPlays
            .GroupBy(spotifyTrack => spotifyTrack.TrackName);

        Tracks = tracks
            .Select(spotifyTrack => new TrackDto(spotifyTrack.First(), spotifyTrack.Count()))
            .OrderByDescending(dto => dto.Count)
            .Take(10);

        ArtistName = track.ArtistName;
        AlbumCount = albums.Count();
        TrackCount = tracks.Count();
        PlayCount = artistPlays.Count();
    }
}