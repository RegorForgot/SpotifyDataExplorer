using SpotifyDataExplorer.Models;

namespace SpotifyDataExplorer.ViewModels.DTOs;

public record AlbumDto(SpotifyTrack Track, int Count) : IViewModelDto;