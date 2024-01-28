using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using ReactiveUI;
using SpotifyDataExplorer.Models;

namespace SpotifyDataExplorer.Stores;

public class TracksDataStore : ReactiveObject
{
    private IEnumerable<SpotifyTrack>? _spotifyTracks;

    public IEnumerable<SpotifyTrack>? SpotifyTracks
    {
        get => _spotifyTracks;
        private set => this.RaiseAndSetIfChanged(ref _spotifyTracks, value);
    }

    public Task PopulateSpotifyTrackListing(IEnumerable<SpotifyTrackDto>? trackDtos)
    {
        SpotifyTracks = trackDtos?.Where(dto => dto.IsValid).Select(dto => new SpotifyTrack(dto)).OrderByDescending(track => track.Timestamp);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<SpotifyTrackDto>?> GetDtosFromJson(IEnumerable<IStorageFile> jsonFiles)
    {
        var dtos = new List<SpotifyTrackDto>();

        foreach (IStorageFile storageFile in jsonFiles)
        {
            IEnumerable<SpotifyTrackDto>? fileDtos;

            try
            {
                using StreamReader sr = new StreamReader(await storageFile.OpenReadAsync());
                fileDtos = await JsonSerializer.DeserializeAsync<IEnumerable<SpotifyTrackDto>>(await storageFile.OpenReadAsync());

            }
            catch (Exception ex)
            {
                fileDtos = Array.Empty<SpotifyTrackDto>();
                Console.WriteLine(ex.Message);
            }

            dtos.AddRange(fileDtos ?? Array.Empty<SpotifyTrackDto>());
        }

        return dtos;
    }
}