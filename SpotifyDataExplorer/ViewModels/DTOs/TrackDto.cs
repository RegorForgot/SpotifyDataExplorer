using SpotifyDataExplorer.Models;

namespace SpotifyDataExplorer.ViewModels.DTOs;

public record TrackDto(SpotifyTrack Track, int Count) : IViewModelDto;