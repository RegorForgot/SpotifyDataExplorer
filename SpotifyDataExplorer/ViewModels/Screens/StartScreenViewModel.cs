using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Pages;
using FilePickerFileTypes = SpotifyDataExplorer.Utilities.FilePickerFileTypes;

namespace SpotifyDataExplorer.ViewModels.Screens;

public class StartScreenViewModel : AbstractScreenViewModel
{
    private readonly TracksDataStore _dataStore;
    private bool _loading;

    public ReactiveCommand<UserControl, Unit> GetJsonFilesCmd { get; }
    public bool Loading
    {
        get => _loading;
        set => this.RaiseAndSetIfChanged(ref _loading, value);
    }

    public StartScreenViewModel(UIContext context) : base(context)
    {
        _dataStore = new TracksDataStore();
        GetJsonFilesCmd = ReactiveCommand.CreateFromTask<UserControl>(AddJsonTracksToStore);
    }

    private async Task AddJsonTracksToStore(UserControl view)
    {
        Loading = true;
        TopLevel? topLevel = TopLevel.GetTopLevel(view);

        var files = await topLevel?.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open endsong JSON files",
                AllowMultiple = true,
                FileTypeFilter = new[] { FilePickerFileTypes.JsonOnly, }
            }
        )!;

        if (files.Count < 1)
        {
            return;
        }

        try
        {
            var dtos = await _dataStore.GetDtosFromJson(files);
            await _dataStore.PopulateSpotifyTrackListing(dtos);

            StartBrowsing();
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private void StartBrowsing()
    {
        Context.AddPage(new HistoryViewModel(Context, _dataStore));
        Context.CurrentScreen = new NavigationScreenViewModel(Context);
    }
}