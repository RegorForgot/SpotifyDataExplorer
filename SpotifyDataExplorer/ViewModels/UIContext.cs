using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using ReactiveUI;
using SpotifyDataExplorer.ViewModels.Pages;

namespace SpotifyDataExplorer.ViewModels;

public class UIContext : ReactiveObject
{
    public AbstractPageViewModel CurrentViewModel => Pages.Last();
    public bool CanGoBack => Pages.Count > 1;

    public List<AbstractPageViewModel> Pages { get; set; } = new List<AbstractPageViewModel>();


    public UIContext() { }

    public void AddPage(AbstractPageViewModel viewModel)
    {
        Pages.Add(viewModel);
        if (Pages.Count > 5)
        {
            Pages.RemoveAt(0);
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
        Pages.Remove(CurrentViewModel);
        this.RaisePropertyChanged(nameof(CanGoBack));
        this.RaisePropertyChanged(nameof(CurrentViewModel));
    }
}