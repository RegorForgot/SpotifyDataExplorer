using System.Linq;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Panels;

public sealed class AlbumViewModel : AbstractPaginatedViewModel<AlbumViewModel.AlbumTrackDto>
{
    public AlbumViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context, dataStore)
    {
        Pages = dataStore.SpotifyTracks!
            .Where(track => track.AlbumName == spotifyTrack.AlbumName && track.ArtistName == spotifyTrack.ArtistName)
            .GroupBy(track => track.TrackName)
            .Select(tracks =>
                new AlbumTrackDto(tracks.First(), tracks.Count())
            )
            .OrderByDescending(dto => dto.Count)
            .Chunk(20)
            .ToList();

        GoToPage(CurrentPageNum);
    }

    public record AlbumTrackDto(SpotifyTrack Track, int Count) : IViewModelDto;
}