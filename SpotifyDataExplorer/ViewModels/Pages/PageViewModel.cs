using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Extensions;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Pages;

public class PageViewModel : AbstractPageViewModel
{
    private readonly UIContext _context;
    private readonly List<SpotifyTrack[]> _trackPages;

    private ObservableCollection<SpotifyTrack> _tracks = new ObservableCollection<SpotifyTrack>();
    private int _currentPage;
    private string _pageText;

    public ObservableCollection<SpotifyTrack> Tracks
    {
        get => _tracks;
        set => this.RaiseAndSetIfChanged(ref _tracks, value);
    }

    public string PageText
    {
        get => _pageText;
        private set => this.RaiseAndSetIfChanged(ref _pageText, value);
    }

    public bool CanGoBack => _currentPage > 0;
    public bool CanGoNext => _trackPages.HasNextPage(_currentPage);

    public ReactiveCommand<Unit, Unit> PreviousPage { get; set; }
    public ReactiveCommand<Unit, Unit> NextPage { get; }
    public ReactiveCommand<Unit, Unit> LastScreen { get; }

    public PageViewModel(UIContext context, TracksDataStore dataStore)
    {
        _context = context;

        if (dataStore.SpotifyTracks == null)
        {
            return;
        }

        _trackPages = dataStore.SpotifyTracks.Chunk(50).ToList();
        NextPage = ReactiveCommand.Create(GoToNextPage);
        PreviousPage = ReactiveCommand.Create(GoToPreviousPage);
        LastScreen = ReactiveCommand.Create(GoToLastScreen);

        GoToPage(_currentPage);
    }

    private void GoToLastScreen()
    {
        _context.BackPage();
    }

    private void GoToNextPage()
    {
        GoToPage(++_currentPage);
    }

    private void GoToPreviousPage()
    {
        GoToPage(--_currentPage);
    }

    private void GoToPage(int number)
    {
        Tracks = new ObservableCollection<SpotifyTrack>(_trackPages[number]);
        this.RaisePropertyChanged(nameof(CanGoBack));
        this.RaisePropertyChanged(nameof(CanGoNext));
        PageText = $"Page {_currentPage + 1} of {_trackPages.Count + 1}";
    }

    public PageViewModel() { }
}