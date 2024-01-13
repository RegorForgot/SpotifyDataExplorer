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

    public ReactiveCommand<IReadOnlyList<IStorageFile>, Unit> GetJsonFilesCmd { get; init; }
    public ReactiveCommand<Unit, Unit> GetSqliteFileCmd { get; init; }

    public StartViewModel(
        TracksDataStore dataStore)
    {
        _dataStore = dataStore;

        GetJsonFilesCmd = ReactiveCommand.CreateFromTask<IReadOnlyList<IStorageFile>>(AddJsonTracksToStore);
    }

    private async Task AddJsonTracksToStore(IReadOnlyList<IStorageFile> files)
    {
        var dtos = await _dataStore.GetDtosFromJson(files);
        await _dataStore.PopulateSpotifyTrackListing(dtos);
    }
}