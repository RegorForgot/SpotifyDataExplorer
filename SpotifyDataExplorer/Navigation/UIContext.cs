using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using SpotifyDataExplorer.ViewModels;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.Navigation;

public class UIContext : ReactiveObject
{
    private AbstractViewModel _currentWindow;
    private readonly List<AbstractPageViewModel> _pages;
    
    public AbstractPageViewModel CurrentViewModel => _pages.Last();
    public bool CanGoBack => _pages.Count > 1;
    
    public AbstractViewModel CurrentWindow
    {
        get => _currentWindow;
        set => this.RaiseAndSetIfChanged(ref _currentWindow, value);
    }
    
    public UIContext()
    {
        _currentWindow = new StartPageViewModel(this);
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
}