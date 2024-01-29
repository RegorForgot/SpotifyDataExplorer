using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels;

public class UIContext : ReactiveObject
{
    private AbstractViewModel _currentWindow;
    public AbstractViewModel CurrentWindow
    {
        get => _currentWindow;
        set => this.RaiseAndSetIfChanged(ref _currentWindow, value);
    }

    private readonly List<AbstractPageViewModel> _pages = new List<AbstractPageViewModel>();
    public AbstractPageViewModel CurrentViewModel => _pages.Last();
    public bool CanGoBack => _pages.Count > 1;


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