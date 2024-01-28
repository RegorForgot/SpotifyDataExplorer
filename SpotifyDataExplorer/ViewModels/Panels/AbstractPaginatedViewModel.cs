using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Extensions;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Stores;

namespace SpotifyDataExplorer.ViewModels.Panels;

public abstract class AbstractPaginatedViewModel : AbstractViewModel
{
    protected readonly UIContext Context;
    protected readonly TracksDataStore DataStore;
    protected List<SpotifyTrack[]> Pages;
    protected int CurrentPage;
    
    private string _pageText;

    public string PageText
    {
        get => _pageText;
        private set => this.RaiseAndSetIfChanged(ref _pageText, value);
    }

    public bool CanGoBack => CurrentPage > 0;
    public bool CanGoNext => Pages.HasNextPage(CurrentPage);

    public ReactiveCommand<Unit, Unit> PreviousPageCmd { get; set; }
    public ReactiveCommand<Unit, Unit> NextPageCmd { get; }

    protected AbstractPaginatedViewModel(UIContext context, TracksDataStore dataStore)
    {
        Context = context;
        DataStore = dataStore;
        NextPageCmd = ReactiveCommand.Create(NextPage);
        PreviousPageCmd = ReactiveCommand.Create(PreviousPage);
    }

    private void NextPage()
    {
        GoToPage(++CurrentPage);
    }

    private void PreviousPage()
    {
        GoToPage(--CurrentPage);
    }

    protected virtual void GoToPage(int number)
    {
        this.RaisePropertyChanged(nameof(CanGoBack));
        this.RaisePropertyChanged(nameof(CanGoNext));
        PageText = $"Page {CurrentPage + 1} of {Pages.Count}";
    }
}