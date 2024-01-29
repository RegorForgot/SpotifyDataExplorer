using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Panels;

public class AlbumViewModel : AbstractPaginatedViewModel
{
    private ObservableCollection<AlbumTrackDto> _tracks;

    public ObservableCollection<AlbumTrackDto> Tracks
    {
        get => _tracks;
        private set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }

    public AlbumViewModel(UIContext context, TracksDataStore dataStore, SpotifyTrack spotifyTrack) : base(context, dataStore)
    {
        Tracks = new ObservableCollection<AlbumTrackDto>(
            dataStore.SpotifyTracks!
                .Where(track => track.AlbumName == spotifyTrack.AlbumName && track.ArtistName == spotifyTrack.ArtistName)
                .GroupBy(track => track.TrackName)
                .Select(tracks =>
                    new AlbumTrackDto(tracks.First(), tracks.Count())
                )
                .OrderByDescending(dto => dto.Count)
        );
    }

    public class AlbumTrackDto
    {
        public AlbumTrackDto(SpotifyTrack track, int count)
        {
            Track = track;
            Count = count;
        }

        public SpotifyTrack Track { get; set; }
        public int Count { get; set; }
    }
}