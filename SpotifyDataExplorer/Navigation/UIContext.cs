using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using SpotifyDataExplorer.ViewModels.Pages;
using SpotifyDataExplorer.ViewModels.Screens;

namespace SpotifyDataExplorer.Navigation;

public class UIContext : ReactiveObject
{
    private AbstractScreenViewModel _currentScreen;
    private readonly List<AbstractPageViewModel> _pages;

    public AbstractPageViewModel CurrentViewModel => _pages.Last();
    public bool CanGoBack => _pages.Count > 1;

    public AbstractScreenViewModel CurrentScreen
    {
        get => _currentScreen;
        set => this.RaiseAndSetIfChanged(ref _currentScreen, value);
    }

    public UIContext()
    {
        _currentScreen = new StartScreenViewModel(this);
        _pages = new List<AbstractPageViewModel>();
    }

    public void AddPage(AbstractPageViewModel viewModel)
    {
        _pages.Add(viewModel);
        if (_pages.Count > 5)
        {
            _pages.RemoveAt(0);
        }
        this.RaisePropertyChanged(nameof(CanGoBack));
        this.RaisePropertyChanged(nameof(CurrentViewModel));
    }

    public void BackPage()
    {
        if (!CanGoBack)
        {
            return;
        }
        _pages.Remove(CurrentViewModel);
        this.RaisePropertyChanged(nameof(CanGoBack));
        this.RaisePropertyChanged(nameof(CurrentViewModel));
    }

    public void RemoveAllPages()
    {
        _pages.Clear();
    }
}