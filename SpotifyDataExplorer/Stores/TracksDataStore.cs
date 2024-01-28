using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using LiteDB;
using Newtonsoft.Json;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace SpotifyDataExplorer.Stores;

public class TracksDataStore : ReactiveObject
{
    private IEnumerable<SpotifyTrack>? _spotifyTracks;

    public IEnumerable<SpotifyTrack>? SpotifyTracks
    {
        get => _spotifyTracks;
        set => this.RaiseAndSetIfChanged(ref _spotifyTracks, value);
    }

    public Task PopulateSpotifyTrackListing(IEnumerable<SpotifyTrackDto>? trackDtos)
    {
        SpotifyTracks = trackDtos?.Where(dto => dto.IsValid).Select(dto => new SpotifyTrack(dto));
        return Task.CompletedTask;
    }
    
    public async Task<IEnumerable<SpotifyTrackDto>?> GetDtosFromJson(IEnumerable<IStorageFile> jsonFiles)
    {
        JsonSerializer serializer = new JsonSerializer();
        var dtos = new List<SpotifyTrackDto>();

        foreach (IStorageFile storageFile in jsonFiles)
        {
            IEnumerable<SpotifyTrackDto>? fileDtos;

            try
            {
                using StreamReader sr = new StreamReader(await storageFile.OpenReadAsync());
                await using JsonTextReader jsonTextReader = new JsonTextReader(sr);
                fileDtos = serializer.Deserialize<IEnumerable<SpotifyTrackDto>>(jsonTextReader);
            }
            catch (JsonSerializationException ex)
            {
                fileDtos = Array.Empty<SpotifyTrackDto>();
                Console.WriteLine(ex.Message);
            }

            dtos.AddRange(fileDtos ?? Array.Empty<SpotifyTrackDto>());
        }

        return dtos;
    }
}