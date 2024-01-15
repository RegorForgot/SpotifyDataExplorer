using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using ReactiveUI;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class StartViewModel : AbstractPageViewModel
{
    private readonly TracksDataStore _dataStore;

    public ReactiveCommand<IEnumerable<IStorageFile>, Unit> GetJsonFilesCmd { get; }
    public ReactiveCommand<Unit, Unit> GetSqliteFileCmd { get; init; }

    public StartViewModel(
        TracksDataStore dataStore)
    {
        _dataStore = dataStore;

        GetJsonFilesCmd = ReactiveCommand.CreateFromTask<IEnumerable<IStorageFile>>(AddJsonTracksToStore);
    }

    private async Task AddJsonTracksToStore(IEnumerable<IStorageFile> files)
    {
        var dtos = await _dataStore.GetDtosFromJson(files);
        await _dataStore.PopulateSpotifyTrackListing(dtos);
    }

    private async Task AddSqliteTracksToStore(IStorageFile file)
    {
        file.
    }
}