using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Panels;

public class TrackViewModel : AbstractPaginatedViewModel
{
    private ObservableCollection<SpotifyTrack> _tracks;

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        private set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }
    
    public TrackViewModel(UIContext context, TracksDataStore dataStore, List<SpotifyTrack[]> pages) : base(context, dataStore)
    {
        Pages = pages;

        GoToPage(CurrentPage);
    }

    protected sealed override void GoToPage(int number)
    {
        Tracks = new ObservableCollection<SpotifyTrack>(Pages[CurrentPage]);
        base.GoToPage(number);
    }
}