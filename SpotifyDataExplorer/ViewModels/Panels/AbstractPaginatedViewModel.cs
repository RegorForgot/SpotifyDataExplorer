using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using SpotifyDataExplorer.Extensions;
using SpotifyDataExplorer.Models;
using SpotifyDataExplorer.Navigation;
using SpotifyDataExplorer.Stores;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels.Panels;

public abstract class AbstractPaginatedViewModel<T> : AbstractPageViewModel where T : IViewModelDto
{
    protected List<T[]> Pages;
    protected int CurrentPageNum;

    private string _pageText;
    private ObservableCollection<T> _currentPage;

    public ObservableCollection<T> CurrentPage
    {
        get => _currentPage;
        protected set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public string PageText
    {
        get => _pageText;
        private set => this.RaiseAndSetIfChanged(ref _pageText, value);
    }

    public bool CanGoBack => CurrentPageNum > 0;
    public bool CanGoNext => Pages.HasNextPage(CurrentPageNum);
    public ReactiveCommand<Unit, Unit> PreviousPageCmd { get; set; }
    public ReactiveCommand<Unit, Unit> NextPageCmd { get; }

    protected AbstractPaginatedViewModel(UIContext context, TracksDataStore dataStore) : base(context, dataStore)
    {
        NextPageCmd = ReactiveCommand.Create(NextPage);
        PreviousPageCmd = ReactiveCommand.Create(PreviousPage);
    }

    private void NextPage()
    {
        GoToPage(++CurrentPageNum);
    }

    private void PreviousPage()
    {
        GoToPage(--CurrentPageNum);
    }

    protected void GoToPage(int number)
    {
        CurrentPage = new ObservableCollection<T>(Pages[CurrentPageNum]);
        this.RaisePropertyChanged(nameof(CanGoBack));
        this.RaisePropertyChanged(nameof(CanGoNext));
        PageText = $"Page {number + 1} of {Pages.Count}";
    }
}