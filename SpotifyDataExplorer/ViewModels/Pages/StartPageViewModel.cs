﻿using System;
using FilePickerFileTypes = SpotifyDataExplorer.Utilities.FilePickerFileTypes;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Panels;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class StartPageViewModel : AbstractPageViewModel
{
    private readonly TracksDataStore _dataStore;
    private bool _loading;

    public ReactiveCommand<UserControl, Unit> GetJsonFilesCmd { get; }
    public bool Loading
    {
        get => _loading;
        set => this.RaiseAndSetIfChanged(ref _loading, value);
    }

    public StartPageViewModel(UIContext context) : base(context)
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

            Context.AddPage(new HistoryViewModel(Context, _dataStore));
            Context.CurrentWindow = new BasePageViewModel(Context);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        Loading = false;
    }
}