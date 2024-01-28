using System;
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

    public StartViewModel(UIContext uiContext) : base(uiContext)
    {
        _dataStore = new TracksDataStore();
        GetJsonFilesCmd = ReactiveCommand.CreateFromTask<IEnumerable<IStorageFile>>(AddJsonTracksToStore);
    }

    private async Task AddJsonTracksToStore(IEnumerable<IStorageFile> files)
    {
        var dtos = await _dataStore.GetDtosFromJson(files);
        await _dataStore.PopulateSpotifyTrackListing(dtos);

        Context.AddPage(new HistoryPageViewModel(Context, _dataStore));
    }
}