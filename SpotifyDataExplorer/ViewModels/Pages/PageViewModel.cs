using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using DynamicData.Binding;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class PageViewModel : AbstractPageViewModel
{
    private readonly UIContext _context;
    private readonly TracksDataStore _dataStore;
    private ObservableCollection<SpotifyTrack> _tracks = new ObservableCollection<SpotifyTrack>();

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }

    public PageViewModel() { }

    public PageViewModel(UIContext context, TracksDataStore dataStore)
    {
        _context = context;
        _dataStore = dataStore;

        if (_dataStore.SpotifyTracks != null)
        {
            _tracks = new ObservableCollection<SpotifyTrack>(
                _dataStore.SpotifyTracks.OrderByDescending(track => track.Timestamp).Chunk(50).First()
            );
        }
    }
}