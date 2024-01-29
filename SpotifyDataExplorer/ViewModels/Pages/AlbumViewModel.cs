using System.Linq;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.DTOs;

namespace SpotifyDataExplorer.ViewModels.Pages;

public sealed class AlbumViewModel : AbstractPaginatedViewModel<TrackDto>
{
    public AlbumViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context, dataStore)
    {
        Pages = dataStore.SpotifyTracks!
            .Where(track => track.AlbumName == spotifyTrack.AlbumName && track.ArtistName == spotifyTrack.ArtistName)
            .GroupBy(track => track.TrackName)
            .Select(tracks =>
                new TrackDto(tracks.First(), tracks.Count())
            )
            .OrderByDescending(dto => dto.Count)
            .Chunk(20)
            .ToList();

        GoToPage(CurrentPageNum);
    }
}