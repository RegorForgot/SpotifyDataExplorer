﻿using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Extensions;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Pages;

public abstract class AbstractPageViewModel : AbstractViewModel
{
    protected readonly TracksDataStore DataStore;
    public ReactiveCommand<SpotifyTrack, Unit> OpenTrackCmd { get; }
    public ReactiveCommand<SpotifyTrack, Unit> OpenAlbumCmd { get; }

    protected AbstractPageViewModel(UIContext context, TracksDataStore dataStore) : base(context)
    {
        DataStore = dataStore;
        OpenTrackCmd = ReactiveCommand.Create<SpotifyTrack>(track => context.OpenTrack(dataStore, track));
        OpenAlbumCmd = ReactiveCommand.Create<SpotifyTrack>(track => context.OpenAlbum(dataStore, track));
    }
}